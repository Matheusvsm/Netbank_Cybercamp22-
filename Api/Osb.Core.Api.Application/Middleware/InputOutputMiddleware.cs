using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Osb.Core.Api.Factory.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Api.Application.Models.Response;
using Osb.Core.Platform.Auth.Service.Models.Result;
using System.Net;
using Osb.Core.Api.Application.Util;
using Osb.Core.Api.Entity;
using Osb.Core.Api.Application.Mapping;

public class InputOutputMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IInputRepositoryFactory _inputRepositoryFactory;
    private readonly IOutputRepositoryFactory _outputRepositoryFactory;
    private Settings _settings;

    public InputOutputMiddleware(
        RequestDelegate next,
        IInputRepositoryFactory inputRepositoryFactory,
        IOutputRepositoryFactory outputRepositoryFactory,
        Settings settings)
    {
        _next = next;
        _inputRepositoryFactory = inputRepositoryFactory;
        _outputRepositoryFactory = outputRepositoryFactory;
        _settings = settings;
    }

    public async Task Invoke(HttpContext context)
    {
        Output result = new Output();
        long? userId = null;

        try
        {
            if (NeedsSaveInputOutput(context))
            {
                var request = await ReadStream(context.Request.Body);
                Input input = await FormatInput(context.Request);
                var hasRequestBody = !string.IsNullOrEmpty(input.Body);
                if (hasRequestBody)
                    input.Body = Formatter.MaskFromCredential(input.Body, request);

                string path = context.Request.Path;

                userId = GetUserId(request);

                if (!path.Contains("swagger"))
                    input = _inputRepositoryFactory.Create().InsertInputLog(input, userId);

                var originalBody = context.Response.Body;

                using (var memoryStream = new MemoryStream())
                {
                    context.Response.Body = memoryStream;
                    await _next.Invoke(context);
                    result = await FormatOutput(context.Response);
                    await memoryStream.CopyToAsync(originalBody);
                    context.Response.Body = originalBody;
                }

                userId = GetUserId(request, result.Response);
                result.InputLogId = input.InputLogId;

                if (result != null)
                {
                    if (Convert.ToInt32(result.StatusCode) == (int)HttpStatusCode.NotFound)
                        throw new NotImplementedException();

                    _outputRepositoryFactory.Create().InsertOutputLog(result, userId);
                }
            }
            else
            {
                await _next.Invoke(context);
                return;
            }
        }
        catch (Exception ex)
        {
            result.Message = ex.Message;
            if (ex is UnauthorizedAccessException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            if (ex is NotImplementedException)
            {
                result.Response = FormatResponse(result.Message);
                _outputRepositoryFactory.Create().InsertOutputLog(result, userId);
            }
            else
            {
                SaveLogFile(result);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
    }

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context) { }

    private static async Task<string> ReadStream(Stream stream)
    {
        stream.Seek(0, SeekOrigin.Begin);

        var reader = new StreamReader(stream);
        var result = await reader.ReadToEndAsync();

        stream.Seek(0, SeekOrigin.Begin);

        return result;
    }

    private static bool NeedsSaveInputOutput(HttpContext context)
    {
        var path = context.Request.Path.ToString().ToLower();
        var method = context.Request.Method;

        return !(path.Contains("auth") && method == HttpMethods.Get);
    }

    private long? GetUserId(string request = null, string response = null)
    {
        if (!string.IsNullOrEmpty(request))
        {
            var requestObj = JsonSerializer.Deserialize<JsonDocument>(request);
            bool hasUserId = requestObj.RootElement.TryGetProperty("userId", out var userIdJsonElement);
            if (hasUserId && userIdJsonElement.TryGetInt64(out long userId))
                return userId;
        }
        else if (!string.IsNullOrEmpty(response))
        {
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var responseObj = JsonSerializer.Deserialize<Response>(response, jsonSerializerOptions);
            if (responseObj.Data is null)
                return _settings.UserDefault;

            var authenticateResult = JsonSerializer.Deserialize<AuthenticateResult>(Convert.ToString(responseObj.Data), jsonSerializerOptions);
            long userId = authenticateResult.UserId;
            return userId;
        }

        return _settings.UserDefault;
    }

    private async Task<Input> FormatInput(HttpRequest request)
    {
        var requestBody = await ReadStream(request.Body);
        Input input = new Input();

        input.Body = requestBody.ToString();
        input.Method = request.Path;
        input.Headers = JsonSerializer.Serialize(request.Headers);

        string[] headers = input.Headers.Split(",");

        foreach (string header in headers)
        {
            if (header.Contains("Origin"))
            {
                string s = header.Substring(11, header.Length - 13);
                input.Url = s;
            }
        }

        return input;
    }

    private async Task<Output> FormatOutput(HttpResponse response)
    {
        Output result = new Output();

        response.Body.Seek(0, SeekOrigin.Begin);


        result.Response = await new StreamReader(response.Body).ReadToEndAsync();
        result.StatusCode = response.StatusCode.ToString();

        response.Body.Seek(0, SeekOrigin.Begin);

        return result;
    }

    private string FormatResponse(string message)
    {
        Response response = ResponseMapper.Map(false, null, message);
        string responseString = JsonSerializer.Serialize(
            response,
            new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            }
        );
        return responseString.ToLower();
    }

    private void SaveLogFile(Output result)
    {
        try
        {
            using var file = File.Open(_settings.LogPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            var reader = new StreamReader(file);
            var fileContent = reader.ReadToEnd();
            file.Position = 0;

            var serializerOptions = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            var newlog = new
            {
                Message = result,
                LogDate = DateTime.Now
            };
            var logs = string.IsNullOrEmpty(fileContent) ? new List<object>() : JsonSerializer.Deserialize<List<object>>(fileContent, serializerOptions);
            logs.Add(newlog);

            StreamWriter writer = new StreamWriter(file);
            writer.Write(JsonSerializer.Serialize(logs, serializerOptions));
            writer.Close();
        }
        catch { }
    }
}
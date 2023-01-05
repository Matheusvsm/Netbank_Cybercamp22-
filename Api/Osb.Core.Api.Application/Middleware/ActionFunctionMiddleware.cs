using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Osb.Core.Api.Common.Resources;
using Osb.Core.Api.Entity;
using Osb.Core.Api.Factory.Repository.Interfaces;
using Osb.Core.Api.Repository;
using Osb.Core.Platform.Common.Entity;

public class ActionFunctionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IActionFunctionRepositoryFactory _actionFunctionRepositoryFactory;
    private readonly Settings _settings;

    public ActionFunctionMiddleware(
        RequestDelegate next,
        IActionFunctionRepositoryFactory actionFunctionRepositoryFactory,
        Settings settings)
    {
        _next = next;
        _actionFunctionRepositoryFactory = actionFunctionRepositoryFactory;
        _settings = settings;
    }

    public async Task Invoke(HttpContext context)
    {
        await CheckPermissionAsync(context);
        await _next.Invoke(context);
    }

    public async Task CheckPermissionAsync(HttpContext context)
    {
        try
        {
            var request = await ReadStream(context.Request.Body);

            string[] path = (context.Request.Path).ToString().Split('/', StringSplitOptions.RemoveEmptyEntries);

            string controller = path[0];

            string action = (path.Length != 2) ? context.Request.Method : path[1];

            long? userId = GetUserId(request);

            long? accountId = GetAccountId(request);

            if (userId != null && accountId != null)
            {
                IActionFunctionRepository actionFuctionRepository = _actionFunctionRepositoryFactory.Create();

                ActionFunction actionFunction = actionFuctionRepository.GetByUserIdAndAccountIdAndActionAndController(userId.Value, accountId.Value, action, controller);

                if (actionFunction == null)
                    throw new UnauthorizedAccessException(ApiExcMsg.ApiExc0006);
            }
        }
        catch (Exception e)
        {
            var message = e.Message;
            context.Response.StatusCode = 403;

            throw new UnauthorizedAccessException(message);
        }
    }

    private long? GetUserId(string request)
    {
        var requestObj = JsonSerializer.Deserialize<JsonDocument>(request);
        bool hasUserId = requestObj.RootElement.TryGetProperty("userId", out var userIdJsonElement);
        if (hasUserId && userIdJsonElement.TryGetInt64(out long userId))
            return userId;
        return null;
    }

    private long? GetAccountId(string request)
    {
        var requestObj = JsonSerializer.Deserialize<JsonDocument>(request);
        bool hasAccountId = requestObj.RootElement.TryGetProperty("accountId", out var accountIdJsonElement);
        if (hasAccountId && accountIdJsonElement.TryGetInt64(out long accountId))
            return accountId;
        return null;
    }


    private static async Task<string> ReadStream(Stream stream)
    {
        stream.Seek(0, SeekOrigin.Begin);

        var reader = new StreamReader(stream);
        var result = await reader.ReadToEndAsync();

        stream.Seek(0, SeekOrigin.Begin);

        return result;
    }

}

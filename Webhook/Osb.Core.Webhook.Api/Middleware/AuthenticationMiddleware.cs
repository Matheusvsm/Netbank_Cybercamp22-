using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Util.Security;
using Osb.Core.Webhook.Api.Models.Request;
using Osb.Core.Webhook.Common;
using Osb.Core.Webhook.Common.Resources;
using Osb.Core.Webhook.Entity;
using Osb.Core.Webhook.Factory.Repository.Interfaces;
using Osb.Core.Webhook.Repository;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IWebhookAuthenticationRepositoryFactory _webhookAuthenticationRepositoryFactory;
    private readonly Settings _settings;

    public AuthenticationMiddleware(
        RequestDelegate next,
        IWebhookAuthenticationRepositoryFactory webhookAuthenticationRepositoryFactory,
        Settings settings)
    {
        _next = next;
        _webhookAuthenticationRepositoryFactory = webhookAuthenticationRepositoryFactory;
        _settings = settings;
    }

    public async Task Invoke(HttpContext context)
    {
        string authorization = context.Request.Headers["Authorization"];
        if (authorization == null || authorization.Length == 0 || !authorization.StartsWith("Basic"))
            throw new UnauthorizedAccessException(WbhExcMsg.WbhExc001);

        try
        {
            var request = await ReadStream(context.Request.Body);
            BaseRequest baseRequest = JsonSerializer.Deserialize<BaseRequest>(request);

            IWebhookAuthenticationRepository webhookAuthenticationRepository = _webhookAuthenticationRepositoryFactory.Create();
            WebhookAuthentication webhookAuthentication = webhookAuthenticationRepository.GetByCompanyId(baseRequest.BusinessUnitId);

            if (webhookAuthentication == null)
                throw new UnauthorizedAccessException(WbhExcMsg.WbhExc002);

            string base64Credentials = authorization.Substring(6);
            string[] credentials = Encoding.ASCII.GetString(Convert.FromBase64String(base64Credentials)).Split(new char[] { ':' });

            if (credentials.Count() != 2 || string.IsNullOrEmpty(credentials[0]) || string.IsNullOrEmpty(credentials[1]))
                throw new UnauthorizedAccessException(WbhExcMsg.WbhExc002);

            bool match = SHA512Provider.Compare(credentials[1], webhookAuthentication.Password, webhookAuthentication.Salt);

            if (!match)
                throw new UnauthorizedAccessException(WbhExcMsg.WbhExc003);

            await _next.Invoke(context);
        }
        catch (Exception e)
        {
            var message = e.Message;
            context.Response.StatusCode = 403;

            throw new OsbApiException(message);
        }
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
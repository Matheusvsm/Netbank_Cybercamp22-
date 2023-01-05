using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Osb.Core.Api.Common;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Entity.Models;
using System.IO;
using System.Net;
using Osb.Core.Platform.Auth.Util.Resources.AuthExcMsg;

public class ApplicationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IApplicationRepositoryFactory _applicationRepositoryFactory;
    private readonly Settings _settings;

    public ApplicationMiddleware(
        RequestDelegate next,
        IApplicationRepositoryFactory applicationRepositoryFactory,
        Settings settings)
    {
        _next = next;
        _applicationRepositoryFactory = applicationRepositoryFactory;
        _settings = settings;
    }

    public async Task Invoke(HttpContext context)
    {
        if (NeedsApplicationHeaders(context))
            DecryptJwt(context);

        await _next.Invoke(context);
    }

    public void DecryptJwt(HttpContext context)
    {
        try
        {
            var (applicationKeyHeader, applicationTokenHeader) = ValidateHeaders(context);

            Application application = _applicationRepositoryFactory.Create().GetApplicationByKey(applicationKeyHeader);
            byte[] secret = Encoding.ASCII.GetBytes(application.Secret);

            new JwtSecurityTokenHandler().ValidateToken(applicationTokenHeader, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secret),
                ValidateIssuer = false,
                ValidateAudience = false,
                // TODO: Adicionar issuer
                RequireExpirationTime = true,
                ValidateTokenReplay = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
            }, out SecurityToken validatedToken);

            var token = (JwtSecurityToken)validatedToken;
            string appKeyClaim = token.Claims.FirstOrDefault(x => x.Type == "app")?.Value;

            if (appKeyClaim != applicationKeyHeader)
                throw new UnauthorizedAccessException(AuthExcMsg.EXC0008);

            context.Items.Add("CompanyId", application.CompanyId);
        }
        catch (System.Exception e)
        {
            if (e is UnauthorizedAccessException)
            {
                throw;
            }

            var message = e.Message;
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            if (e is SecurityTokenExpiredException)
            {
                message = AuthExcMsg.EXC0009;
            }

            if (e is SecurityTokenInvalidSignatureException)
            {
                message = AuthExcMsg.EXC0010;
            }

            throw new UnauthorizedAccessException(message);
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

    private static bool NeedsApplicationHeaders(HttpContext context)
    {
        var path = context.Request.Path.ToString().ToLower();
        var method = context.Request.Method;

        return !(path.Contains("auth") && method == HttpMethods.Get);
    }

    private static (string, string) ValidateHeaders(HttpContext context)
    {
        context.Request.Headers.TryGetValue("x-application-key", out var applicationKeyHeader);
        context.Request.Headers.TryGetValue("x-application-token", out var applicationTokenHeader);

        if (string.IsNullOrEmpty(applicationKeyHeader) || string.IsNullOrEmpty(applicationTokenHeader))
            throw new OsbApiException(AuthExcMsg.EXC0008);

        return (
            applicationKeyHeader,
            applicationTokenHeader
        );
    }
}
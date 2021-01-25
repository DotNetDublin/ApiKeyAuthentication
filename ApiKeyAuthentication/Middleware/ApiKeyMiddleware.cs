using ApiKeyAuthentication.Data;
using ApiKeyAuthentication.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ApiKeyAuthentication.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string AppId = "X-APP-ID";
        private const string ApiKeyName = "X-API-KEY";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IApiClientRepository apiClientRepository, ILogger<ApiKeyMiddleware> logger)
        {
            var ipAddress = context.Connection.RemoteIpAddress.ToString();

            if (!context.Request.Headers.TryGetValue(AppId, out var extractedAppId))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("App Id was not provided");
                logger.LogWarning($"App Id was not provided in request from {ipAddress}");
                return;
            }

            if (!context.Request.Headers.TryGetValue(ApiKeyName, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not provided");
                logger.LogWarning($"App Key was not provided in request from {ipAddress}");
                return;
            }

            ApiClient apiClient = apiClientRepository.GetApiClient(extractedAppId, extractedApiKey);

            if (apiClient == null || apiClient.IsActive == false)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorised client");
                logger.LogWarning($"Unauthorised client in request from {ipAddress}");
                return;
            }

            logger.LogWarning($"Client {apiClient.ClientName} authenticated in request from {ipAddress}");

            await _next(context);
        }
    }
}
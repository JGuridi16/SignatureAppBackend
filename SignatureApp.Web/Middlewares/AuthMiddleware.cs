using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using SignatureApp.Web.Models;

namespace SignatureApp.Web.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, AppSettings appSettings)
        {
            var isApiKeyExtracted = context.Request.Headers.TryGetValue("X-Api-Key", out StringValues extractedKeyValue);
            if (!isApiKeyExtracted)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Missing API Key");
                return;
            }

            var isValidKey = extractedKeyValue == appSettings.ApiKey;
            if(!isValidKey)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid API Key");
                return;
            }

            await _next(context);
        }
    }
}
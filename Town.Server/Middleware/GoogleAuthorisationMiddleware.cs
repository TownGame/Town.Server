using Google.Apis.Auth;
using System.Net;

namespace Town.Server.Middleware;

public class GoogleAuthorisationMiddleware : IMiddleware {
    public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
        string token = context.Request.Query["token"];
        if (string.IsNullOrEmpty(token)) {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return;
        }

        try {
            await GoogleJsonWebSignature.ValidateAsync(token);
        } catch (InvalidJwtException) {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return;
        }
        await next.Invoke(context);
    }
}

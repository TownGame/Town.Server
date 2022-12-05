namespace Town.Server.Middleware;

public static class GoogleAuthorisationMiddlewareExtensions {
    public static IApplicationBuilder UseGoogleAuthorisationMiddleware(this IApplicationBuilder app) {
        return app.UseMiddleware<GoogleAuthorisationMiddleware>();
    }
}

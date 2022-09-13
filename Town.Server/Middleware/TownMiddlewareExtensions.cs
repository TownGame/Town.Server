namespace Town.Server.Middleware;

public static class TownMiddlewareExtensions {
    public static IApplicationBuilder UseTownMiddleware(this IApplicationBuilder app) {
        return app.UseMiddleware<TownMiddleware>();
    }
}

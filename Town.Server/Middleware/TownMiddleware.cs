using System.Net;
using System.Net.WebSockets;

namespace Town.Server.Middleware;

public class TownMiddleware : IMiddleware {
    public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
        if (context.Request.Path == "/game") {
            await Initiate(context);
        } else {
            await next(context);
        }
    }

    private async Task Initiate(HttpContext context) {
        if (!context.WebSockets.IsWebSocketRequest) {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return;
        }
        WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
        await Listen(webSocket);
    }

    private async Task Listen(WebSocket webSocket) {
        byte[] buffer = new byte[1024 * 4];
        while (webSocket.State == WebSocketState.Open) {
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        }
    }
}

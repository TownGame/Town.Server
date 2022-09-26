using System.Net;
using System.Net.WebSockets;
using Town.Server.Core;
using Town.Server.Core.Network;
using Town.Server.Core.Players;

namespace Town.Server.Middleware;

public class TownMiddleware : IMiddleware {
    private readonly TownServer Server = new TownServer();

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
        NetworkHandler networkHandler = new NetworkHandler(webSocket);
        Player player = new Player(networkHandler);
        await Server.JoinLobby(player);
        await networkHandler.Listen();
    }
}

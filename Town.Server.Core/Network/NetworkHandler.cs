using System.Net.WebSockets;
using Town.Server.Core.Network.Packets;

namespace Town.Server.Core.Network;

public class NetworkHandler {
    private readonly WebSocket WebSocket;
    private readonly byte[] Buffer = new byte[1024 * 4];

    public NetworkHandler(WebSocket webSocket) {
        WebSocket = webSocket;
    }

    public async Task SendPacket<T>(T packet) where T : IPacket {
        if (WebSocket.State != WebSocketState.Open) {
            return;
        }

        using MemoryStream memoryStream = new MemoryStream();
        using BinaryWriter writer = new BinaryWriter(memoryStream);
        writer.WriteInt(packet.PacketType.Id);
        packet.Write(writer);
        await WebSocket.SendAsync(memoryStream.ToArray(), WebSocketMessageType.Binary, true, CancellationToken.None);
    }

    public async Task Listen() {
        while (WebSocket.State == WebSocketState.Open) {
            WebSocketReceiveResult result = await WebSocket.ReceiveAsync(new ArraySegment<byte>(Buffer), CancellationToken.None);
            await Handle(result);
        }
    }

    private async Task Handle(WebSocketReceiveResult result) {
        if (result.MessageType == WebSocketMessageType.Binary) {
            HandlePacket();
        } else if (result.MessageType == WebSocketMessageType.Close) {
            await WebSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "Client disconnected", CancellationToken.None);
        }
    }

    private void HandlePacket() {
        using MemoryStream memoryStream = new MemoryStream(Buffer);
        using BinaryReader reader = new BinaryReader(memoryStream);

        int id = reader.ReadInt();
    }
}

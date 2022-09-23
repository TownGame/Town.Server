using System.Net.WebSockets;
using Town.Server.Core.Network.Packets;

namespace Town.Server.Core.Network;

public class NetworkHandler {
    private readonly WebSocket WebSocket;

    public NetworkHandler(WebSocket webSocket) {
        WebSocket = webSocket;
    }

    public async Task SendPacket<T>(T packet) where T : IPacket {
        using MemoryStream memoryStream = new MemoryStream();
        using BinaryWriter writer = new BinaryWriter(memoryStream);
        writer.WriteInt(packet.PacketType.Id);
        packet.Write(writer);
        await WebSocket.SendAsync(memoryStream.ToArray(), WebSocketMessageType.Binary, true, CancellationToken.None);
    }
}

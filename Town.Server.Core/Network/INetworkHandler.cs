using Town.Server.Core.Network.Packets;

namespace Town.Server.Core.Network;

public interface INetworkHandler {
    Task SendPacket<T>(T packet) where T : IPacket;
    Task Listen();
}

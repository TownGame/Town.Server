using Town.Server.Core.Network;
using Town.Server.Core.Network.Packets;

namespace Town.Server.Core.Tests;

public class NetworkHandlerMock : INetworkHandler {
    private bool Connected;

    public NetworkHandlerMock() : this(true) { }

    public NetworkHandlerMock(bool connected) {
        Connected = connected;
    }

    public async Task Listen() {
        while (Connected) { }
    }

    public async Task SendPacket<T>(T packet) where T : IPacket { }

    public void Disconnect() {
        Connected = false;
    }
}

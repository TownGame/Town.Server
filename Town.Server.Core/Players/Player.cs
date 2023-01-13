using Town.Server.Core.Network;

namespace Town.Server.Core.Players;

public class Player {
    public INetworkHandler NetworkHandler { get; }

    public Player(INetworkHandler networkHandler) {
        NetworkHandler = networkHandler;
    }
}

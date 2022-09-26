using Town.Server.Core.Network;

namespace Town.Server.Core.Players;

public class Player {
    public NetworkHandler NetworkHandler { get; }

    public Player(NetworkHandler networkHandler) {
        NetworkHandler = networkHandler;
    }
}

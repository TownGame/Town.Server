using Town.Server.Core.Network.Packets;
using Town.Server.Core.Players;

namespace Town.Server.Core.Lobbies;

public class Lobby {
    private const int MAX_PLAYER_COUNT = 15;

    private readonly List<Player> Players = new List<Player>(MAX_PLAYER_COUNT);

    public async Task<bool> TryJoin(Player player) {
        if (Players.Count == MAX_PLAYER_COUNT) {
            return false;
        }
        await player.NetworkHandler.SendPacket(new JoinLobbyPacket(Players.Count));
        Players.Add(player);
        return true;
    }
}

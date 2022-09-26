using Town.Server.Core.Lobbies;
using Town.Server.Core.Players;

namespace Town.Server.Core;

public class TownServer {
    private readonly LobbyCollection Lobbies = new LobbyCollection();

    public async Task JoinLobby(Player player) {
        await Lobbies.Join(player);
    }
}

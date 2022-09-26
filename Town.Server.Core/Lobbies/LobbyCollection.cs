using System.Collections;
using Town.Server.Core.Players;

namespace Town.Server.Core.Lobbies;

public class LobbyCollection : IEnumerable<Lobby> {
    private readonly List<Lobby> Lobbies = new List<Lobby>();

    public IEnumerator<Lobby> GetEnumerator() {
        foreach (Lobby lobby in Lobbies) {
            yield return lobby;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    public async Task Join(Player player) {
        Console.WriteLine($"Lobby count: {Lobbies.Count}");
        foreach (Lobby lobby in Lobbies) {
            if (await lobby.TryJoin(player)) {
                return;
            }
        }
        await CreateLobby(player);
    }

    private async Task CreateLobby(Player player) {
        Console.WriteLine("Create lobby");
        Lobby lobby = new Lobby();
        Lobbies.Add(lobby);
        Console.WriteLine($"Lobby created, new count: {Lobbies.Count}");
        await lobby.TryJoin(player);
    }
}

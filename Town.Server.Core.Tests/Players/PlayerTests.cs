using Town.Server.Core.Players;

namespace Town.Server.Core.Tests.Players;

[TestClass]
public class PlayerTests {
    [TestMethod]
    public void NewInstance_ShouldHaveNetworkHandlerSet() {
        NetworkHandlerMock networkHandler = new NetworkHandlerMock();
        Player player = new Player(networkHandler);
        Assert.IsNotNull(player.NetworkHandler);
    }
}

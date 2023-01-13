namespace Town.Server.Core.Network.Packets;

public static class AllPackets {
    private static readonly Dictionary<int, Func<IPacket>> PACKETS = new Dictionary<int, Func<IPacket>>() {
    };

    public static IPacket CreatePacket(int id) {
        if (!PACKETS.TryGetValue(id, out Func<IPacket>? packetCreator)) {
            throw new Exception($"Invalid packet ID {id}");
        }
        return packetCreator();
    }
}

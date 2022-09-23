namespace Town.Server.Core.Network.Packets.Types;

public class PacketType : IPacketType {
    public int Id { get; }

    public PacketType(int id) {
        Id = id;
    }
}

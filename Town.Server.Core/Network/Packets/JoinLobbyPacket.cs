using Town.Server.Core.Network.Packets.Types;

namespace Town.Server.Core.Network.Packets;

public class JoinLobbyPacket : IPacket {
    private int Id;

    public IPacketType PacketType { get { return PacketTypes.JOIN_LOBBY_PACKET_TYPE; } }

    public JoinLobbyPacket() : this(-1) { }

    public JoinLobbyPacket(int id) { Id = id; }

    public void Read(BinaryReader reader) {
        Id = reader.ReadInt();
    }

    public void Write(BinaryWriter writer) {
        writer.WriteInt(Id);
    }
}

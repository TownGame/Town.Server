using Town.Server.Core.Network.Packets.Types;

namespace Town.Server.Core.Network.Packets;

public class JoinLobbyPacket : IPacket {
    private int PlayerCount;

    public IPacketType PacketType { get { return PacketTypes.JOIN_LOBBY; } }

    public JoinLobbyPacket() : this(0) { }

    public JoinLobbyPacket(int playerCount) { PlayerCount = playerCount; }

    public void Read(BinaryReader reader) {
        PlayerCount = reader.ReadInt();
    }

    public void Write(BinaryWriter writer) {
        writer.WriteInt(PlayerCount);
    }
}

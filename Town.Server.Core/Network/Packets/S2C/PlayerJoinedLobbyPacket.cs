using Town.Server.Core.Network.Packets.Types;

namespace Town.Server.Core.Network.Packets.S2C;

public class PlayerJoinedLobbyPacket : IPacket {
    public IPacketType PacketType { get { return PacketTypes.PLAYER_JOINED_LOBBY; } }

    public void Read(BinaryReader reader) { }

    public void Write(BinaryWriter writer) { }
}

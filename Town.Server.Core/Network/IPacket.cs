using Town.Server.Core.Network.Packets.Types;

namespace Town.Server.Core.Network;

public interface IPacket {
    IPacketType PacketType { get; }
    void Read(BinaryReader reader);
    void Write(BinaryWriter writer);
}

﻿namespace Town.Server.Core.Network.Packets.Types;

public static class PacketTypes {
    public static readonly PacketType JOIN_LOBBY = new PacketType(1);
    public static readonly PacketType PLAYER_JOINED_LOBBY = new PacketType(2);
}

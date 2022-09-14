namespace Town.Server.Core.Network;

internal class BinaryWriter : IDisposable {
    private readonly Stream Stream;
    private readonly byte[] Buffer = new byte[sizeof(long)];

    public BinaryWriter(Stream stream) {
        Stream = stream;
    }

    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void WriteBoolean(bool value) {
        WriteUnsignedByte((byte)(value ? 1 : 0));
    }

    public void WriteByte(sbyte value) {
        WriteUnsignedByte((byte)value);
    }

    public void WriteUnsignedByte(byte value) {
        Buffer[0] = value;
        WriteBuffer(1);
    }

    public void WriteShort(short value) {
        Buffer[0] = (byte)(value >> 8 & 0xFF);
        Buffer[1] = (byte)(value & 0xFF);
        WriteBuffer(2);
    }

    public void WriteUnsignedShort(ushort value) {
        WriteShort((short)value);
    }

    public void WriteInt(int value) {
        for (int i = 0; i < 4; i++) {
            Buffer[i] = (byte)(value >> ((3 - i) * 8) & 0xFF);
        }
        WriteBuffer(4);
    }

    public void WriteUnsignedInt(uint value) {
        WriteInt((int)value);
    }

    public void WriteLong(long value) {
        for (int i = 0; i < 8; i++) {
            Buffer[i] = (byte)(value >> ((7 - i) * 8) & 0xFF);
        }
        WriteBuffer(8);
    }

    public void WriteUnsignedLong(ulong value) {
        WriteLong((long)value);
    }

    public unsafe void WriteFloat(float value) {
        WriteInt(*(int*)&value);
    }

    public unsafe void WriteDouble(double value) {
        WriteLong(*(long*)&value);
    }

    protected virtual void Dispose(bool disposing) {
        if (disposing) {
            Stream.Dispose();
        }
    }

    private void WriteBuffer(int length) {
        Stream.Write(Buffer, 0, length);
    }
}

namespace Town.Server.Core.Network;

public class BinaryReader : IDisposable {
    private readonly Stream Stream;
    private readonly byte[] Buffer = new byte[sizeof(long)];

    public BinaryReader(Stream stream) {
        Stream = stream;
    }

    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public bool ReadBoolean() {
        return ReadUnsignedByte() != 0;
    }

    public sbyte ReadByte() {
        return (sbyte)ReadUnsignedByte();
    }

    public byte ReadUnsignedByte() {
        FillBuffer(1);
        return Buffer[0];
    }

    public short ReadShort() {
        FillBuffer(2);
        return (short)(Buffer[0] << 8 | Buffer[1]);
    }

    public ushort ReadUnsignedShort() {
        return (ushort)ReadShort();
    }

    public int ReadInt() {
        FillBuffer(4);
        return Buffer[0] << 24 | Buffer[1] << 16 | Buffer[2] << 8 | Buffer[3];
    }

    public uint ReadUnsignedInt() {
        return (uint)ReadInt();
    }

    public long ReadLong() {
        return (long)ReadUnsignedLong();
    }

    public ulong ReadUnsignedLong() {
        FillBuffer(8);
        uint upper = (uint)(Buffer[0] << 24 | Buffer[1] << 16 | Buffer[2] << 8 | Buffer[3]);
        uint lower = (uint)(Buffer[4] << 24 | Buffer[5] << 16 | Buffer[6] << 8 | Buffer[7]);
        return (ulong)upper << 32 | lower;
    }

    public unsafe float ReadFloat() {
        int i = ReadInt();
        return *(float*)&i;
    }

    public unsafe double ReadDouble() {
        ulong l = ReadUnsignedLong();
        return *(double*)&l;
    }

    protected virtual void Dispose(bool disposing) {
        if (disposing) {
            Stream.Dispose();
        }
    }

    private void FillBuffer(int length) {
        int bytesRead = Stream.Read(Buffer, 0, length);
        if (bytesRead < length) {
            throw new EndOfStreamException();
        }
    }
}

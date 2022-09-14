using System.IO;
using BinaryWriter = Town.Server.Core.Network.BinaryWriter;

namespace Town.Server.Core.Tests.Network;

[TestClass]
public class BinaryWriterTests {
    [TestMethod]
    public void WriteBoolean_ShouldWriteCorrectBytes() {
        bool value = true;
        using MemoryStream memoryStream = new MemoryStream();
        using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

        binaryWriter.WriteBoolean(value);
        byte[] data = memoryStream.ToArray();

        CollectionAssert.AreEqual(new byte[] { 0x01 }, data);
    }

    [TestMethod]
    public void WriteByte_ShouldWriteCorrectBytes() {
        sbyte value = -128;
        using MemoryStream memoryStream = new MemoryStream();
        using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

        binaryWriter.WriteByte(value);
        byte[] data = memoryStream.ToArray();

        CollectionAssert.AreEqual(new byte[] { 0x80 }, data);
    }

    [TestMethod]
    public void WriteUnsignedByte_ShouldWriteCorrectBytes() {
        byte value = 128;
        using MemoryStream memoryStream = new MemoryStream();
        using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

        binaryWriter.WriteUnsignedByte(value);
        byte[] data = memoryStream.ToArray();

        CollectionAssert.AreEqual(new byte[] { 0x80 }, data);
    }

    [TestMethod]
    public void WriteShort_ShouldWriteCorrectBytes() {
        short value = -32768;
        using MemoryStream memoryStream = new MemoryStream();
        using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

        binaryWriter.WriteShort(value);
        byte[] data = memoryStream.ToArray();

        CollectionAssert.AreEqual(new byte[] { 0x80, 0x00 }, data);
    }

    [TestMethod]
    public void WriteUnsignedShort_ShouldWriteCorrectBytes() {
        ushort value = 32768;
        using MemoryStream memoryStream = new MemoryStream();
        using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

        binaryWriter.WriteUnsignedShort(value);
        byte[] data = memoryStream.ToArray();

        CollectionAssert.AreEqual(new byte[] { 0x80, 0x00 }, data);
    }

    [TestMethod]
    public void WriteInt_ShouldWriteCorrectBytes() {
        int value = -2147483648;
        using MemoryStream memoryStream = new MemoryStream();
        using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

        binaryWriter.WriteInt(value);
        byte[] data = memoryStream.ToArray();

        CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00 }, data);
    }

    [TestMethod]
    public void WriteUnsignedInt_ShouldWriteCorrectBytes() {
        uint value = 2147483648;
        using MemoryStream memoryStream = new MemoryStream();
        using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

        binaryWriter.WriteUnsignedInt(value);
        byte[] data = memoryStream.ToArray();

        CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00 }, data);
    }

    [TestMethod]
    public void WriteLong_ShouldWriteCorrectBytes() {
        long value = -9223372036854775808L;
        using MemoryStream memoryStream = new MemoryStream();
        using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

        binaryWriter.WriteLong(value);
        byte[] data = memoryStream.ToArray();

        CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, data);
    }

    [TestMethod]
    public void WriteUnsignedLong_ShouldWriteCorrectBytes() {
        ulong value = 9223372036854775808L;
        using MemoryStream memoryStream = new MemoryStream();
        using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

        binaryWriter.WriteUnsignedLong(value);
        byte[] data = memoryStream.ToArray();

        CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, data);
    }

    [TestMethod]
    public void WriteFloat_ShouldWriteCorrectBytes() {
        float value = -1.5f;
        using MemoryStream memoryStream = new MemoryStream();
        using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

        binaryWriter.WriteFloat(value);
        byte[] data = memoryStream.ToArray();

        CollectionAssert.AreEqual(new byte[] { 0xBF, 0xC0, 0x00, 0x00 }, data);
    }

    [TestMethod]
    public void WriteDouble_ShouldWriteCorrectBytes() {
        double value = -1.5d;
        using MemoryStream memoryStream = new MemoryStream();
        using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

        binaryWriter.WriteDouble(value);
        byte[] data = memoryStream.ToArray();

        CollectionAssert.AreEqual(new byte[] { 0xBF, 0xF8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, data);
    }
}

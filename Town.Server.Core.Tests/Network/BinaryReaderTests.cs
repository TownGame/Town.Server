﻿using System;
using System.IO;
using BinaryReader = Town.Server.Core.Network.BinaryReader;

namespace Town.Server.Core.Tests.Network;

[TestClass]
public class BinaryReaderTests {
    [TestMethod]
    public void ReadBoolean_ShouldReturnFalse() {
        byte[] data = new byte[] { 0x00 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        bool result = binaryReader.ReadBoolean();
        Assert.AreEqual(false, result);
    }

    [TestMethod]
    public void ReadBoolean_ShouldReturnTrue() {
        byte[] data = new byte[] { 0x01 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        bool result = binaryReader.ReadBoolean();
        Assert.AreEqual(true, result);
    }

    [TestMethod]
    public void ReadBoolean_ShouldReturnTrue_WithNonZeroInput() {
        byte[] data = new byte[] { 0x10 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        bool result = binaryReader.ReadBoolean();
        Assert.AreEqual(true, result);
    }

    [TestMethod]
    public void ReadBoolean_ShouldThrowEndOfStreamException_BecauseEndOfStreamWasReached() {
        byte[] data = Array.Empty<byte>();
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadBoolean());
    }


    [TestMethod]
    public void ReadByte_ShouldReturnCorrectByte() {
        byte[] data = new byte[] { 0x80 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        sbyte result = binaryReader.ReadByte();
        Assert.AreEqual((sbyte)-128, result);
    }

    [TestMethod]
    public void ReadByte_ShouldThrowEndOfStreamException_BecauseEndOfStreamWasReached() {
        byte[] data = Array.Empty<byte>();
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadByte());
    }

    [TestMethod]
    public void ReadUnsignedByte_ShouldReturnCorrectUnsignedByte() {
        byte[] data = new byte[] { 0x80 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        byte result = binaryReader.ReadUnsignedByte();
        Assert.AreEqual((byte)128, result);
    }

    [TestMethod]
    public void ReadUnsignedByte_ShouldThrowEndOfStreamException_BecauseEndOfStreamWasReached() {
        byte[] data = Array.Empty<byte>();
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadUnsignedByte());
    }

    [TestMethod]
    public void ReadShort_ShouldReturnCorrectShort() {
        byte[] data = new byte[] { 0x80, 0x00 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        short result = binaryReader.ReadShort();
        Assert.AreEqual((short)-32768, result);
    }

    [TestMethod]
    public void ReadShort_ShouldThrowEndOfStreamException_BecauseEndOfStreamWasReached() {
        byte[] data = new byte[] { 0x80 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadShort());
    }

    [TestMethod]
    public void ReadUnsignedShort_ShouldReturnCorrectUnsignedShort() {
        byte[] data = new byte[] { 0x80, 0x00 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        ushort result = binaryReader.ReadUnsignedShort();
        Assert.AreEqual((ushort)32768, result);
    }

    [TestMethod]
    public void ReadUnsignedShort_ShouldThrowEndOfStreamException_BecauseEndOfStreamWasReached() {
        byte[] data = new byte[] { 0x80 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadUnsignedShort());
    }

    [TestMethod]
    public void ReadInt_ShouldReturnCorrectInt() {
        byte[] data = new byte[] { 0x80, 0x00, 0x00, 0x00 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        int result = binaryReader.ReadInt();
        Assert.AreEqual(-2147483648, result);
    }

    [TestMethod]
    public void ReadInt_ShouldThrowEndOfStreamException_BecauseEndOfStreamWasReached() {
        byte[] data = new byte[] { 0x80, 0x00, 0x00 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadInt());
    }

    [TestMethod]
    public void ReadUnsignedInt_ShouldReturnCorrectUnsignedInt() {
        byte[] data = new byte[] { 0x80, 0x00, 0x00, 0x00 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        uint result = binaryReader.ReadUnsignedInt();
        Assert.AreEqual(2147483648, result);
    }

    [TestMethod]
    public void ReadUnsignedInt_ShouldThrowEndOfStreamException_BecauseEndOfStreamWasReached() {
        byte[] data = new byte[] { 0x80, 0x00, 0x00 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadUnsignedInt());
    }

    [TestMethod]
    public void ReadLong_ShouldReturnCorrectLong() {
        byte[] data = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        long result = binaryReader.ReadLong();
        Assert.AreEqual(-9223372036854775808L, result);
    }

    [TestMethod]
    public void ReadLong_ShouldThrowEndOfStreamException_BecauseEndOfStreamWasReached() {
        byte[] data = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadLong());
    }

    [TestMethod]
    public void ReadUnsignedLong_ShouldReturnCorrectUnsignedLong() {
        byte[] data = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        ulong result = binaryReader.ReadUnsignedLong();
        Assert.AreEqual(9223372036854775808L, result);
    }

    [TestMethod]
    public void ReadUnsignedLong_ShouldThrowEndOfStreamException_BecauseEndOfStreamWasReached() {
        byte[] data = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadUnsignedLong());
    }

    [TestMethod]
    public void ReadFloat_ShouldReturnCorrectFloat() {
        byte[] data = new byte[] { 0xBF, 0xC0, 0x00, 0x00 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        float result = binaryReader.ReadFloat();
        Assert.AreEqual(-1.5f, result);
    }

    [TestMethod]
    public void ReadFloat_ShouldThrowEndOfStreamException_BecauseEndOfStreamWasReached() {
        byte[] data = new byte[] { 0xBF, 0xC0, 0x00 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadFloat());
    }

    [TestMethod]
    public void ReadDouble_ShouldReturnCorrectDouble() {
        byte[] data = new byte[] { 0xBF, 0xF8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        double result = binaryReader.ReadDouble();
        Assert.AreEqual(-1.5d, result);
    }

    [TestMethod]
    public void ReadDouble_ShouldThrowEndOfStreamException_BecauseEndOfStreamWasReached() {
        byte[] data = new byte[] { 0xBF, 0xF8, 0x00, 0x00, 0x00, 0x00, 0x00 };
        using MemoryStream memoryStream = new MemoryStream(data);
        using BinaryReader binaryReader = new BinaryReader(memoryStream);

        Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadDouble());
    }
}

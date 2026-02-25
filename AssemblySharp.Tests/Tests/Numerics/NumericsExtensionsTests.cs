namespace AssemblySharp.Tests.Tests.Numerics;

[GenerateGenericTest(typeof(byte))]
[GenerateGenericTest(typeof(sbyte))]
[GenerateGenericTest(typeof(short))]
[GenerateGenericTest(typeof(ushort))]
[GenerateGenericTest(typeof(int))]
[GenerateGenericTest(typeof(uint))]
[GenerateGenericTest(typeof(long))]
[GenerateGenericTest(typeof(ulong))]
[GenerateGenericTest(typeof(nint))]
[GenerateGenericTest(typeof(nuint))]
[GenerateGenericTest(typeof(float))]
[GenerateGenericTest(typeof(double))]
[GenerateGenericTest(typeof(decimal))]
public class NumericsExtensionsTests<TNumberType>
	where TNumberType : INumber<TNumberType>
{
	private static bool BytesEqual(byte[] actual, byte[] expected) => actual.AsSpan().SequenceEqual(expected);

	[Test]
	public async Task GetBytes_WhenNumberProvided_ReturnBytes()
	{
		// Arrange
		var number = TNumberType.One;

		// Act
		var bytes = number.GetBytes();

		// Assert
		_ = typeof(TNumberType).Name switch
		{
			nameof(Byte) or nameof(SByte) => await Assert.That(BytesEqual(bytes, [0x01])).IsTrue(),
			nameof(Int16) or nameof(UInt16) => await Assert.That(BytesEqual(bytes, [0x01, 0x00])).IsTrue(),
			nameof(Int32) or nameof(UInt32) => await Assert.That(BytesEqual(bytes, [0x01, 0x00, 0x00, 0x00])).IsTrue(),
			nameof(Int64) or nameof(UInt64) => await Assert.That(BytesEqual(bytes, [0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00])).IsTrue(),
			nameof(IntPtr) or nameof(UIntPtr) when IntPtr.Size == 4 => await Assert.That(BytesEqual(bytes, [0x01, 0x00, 0x00, 0x00])).IsTrue(),
			nameof(IntPtr) or nameof(UIntPtr) when IntPtr.Size == 8 => await Assert.That(BytesEqual(bytes, [0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00])).IsTrue(),
			nameof(Single) => await Assert.That(BytesEqual(bytes, [0x00, 0x00, 0x80, 0x3F])).IsTrue(),
			nameof(Double) => await Assert.That(BytesEqual(bytes, [0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF0, 0x3F])).IsTrue(),
			nameof(Decimal) => await Assert.That(BytesEqual(bytes, [0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00])).IsTrue(),
			_ => false,
		};
	}

	[Test]
	public async Task GetBitsSize_WhenNumberProvided_ReturnBitsSize()
	{
		// Arrange
		var number = TNumberType.One;

		// Act
		var bitsSize = number.GetBitsSize();

		// Assert
		_ = typeof(TNumberType).Name switch
		{
			nameof(Byte) or nameof(SByte) => await Assert.That(bitsSize).IsEqualTo(8),
			nameof(Int16) or nameof(UInt16) => await Assert.That(bitsSize).IsEqualTo(16),
			nameof(Int32) or nameof(UInt32) => await Assert.That(bitsSize).IsEqualTo(32),
			nameof(Int64) or nameof(UInt64) => await Assert.That(bitsSize).IsEqualTo(64),
			nameof(IntPtr) or nameof(UIntPtr) when IntPtr.Size == 4 => await Assert.That(bitsSize).IsEqualTo(32),
			nameof(IntPtr) or nameof(UIntPtr) when IntPtr.Size == 8 => await Assert.That(bitsSize).IsEqualTo(64),
			nameof(Single) => await Assert.That(bitsSize).IsEqualTo(32),
			nameof(Double) => await Assert.That(bitsSize).IsEqualTo(64),
			nameof(Decimal) => await Assert.That(bitsSize).IsEqualTo(128),
			_ => 0,
		};
	}
}

public class NumericsExtensionsTests
{
	[Test]
	public async Task GetBytes_WhenNumberTypeNotSupported_ThrowNotSupportedException()
	{
		// Arrange
		var number = new Int128(1, 1);

		//Act
		byte[] bytes() => number.GetBytes();

		//Assert
		_ = await Assert.That(bytes).Throws<NotSupportedException>().WithMessage($"There is no definition for getting bytes from a number of type '{typeof(Int128).Name}'");
	}

	[Test]
	public async Task GetBitsSize_WhenNumberTypeNotSupported_ThrowNotSupportedException()
	{
		// Arrange
		var number = new Int128(1, 1);

		//Act
		int size() => number.GetBitsSize();

		//Assert
		_ = await Assert.That(size).Throws<NotSupportedException>().WithMessage($"There is no definition for getting the bits size from a number of type '{typeof(Int128).Name}'");
	}
}

namespace AssemblySharp.Tests.Tests.Numerics;

public class NumericsExtensionsTests
{
    public static IEnumerable<object[]> GetData(bool isExceptionTest)
    {
        if (isExceptionTest)
        {
            yield return new object[] { new Int128(1, 1) };
            yield break;
        }

        yield return new object[] { (byte)0x01 };
        yield return new object[] { (sbyte)0x01 };

        yield return new object[] { (short)0x01 };
        yield return new object[] { (ushort)0x01 };

        yield return new object[] { (int)0x01 };
        yield return new object[] { (uint)0x01 };

        yield return new object[] { (long)0x01 };
        yield return new object[] { (ulong)0x01 };

        yield return new object[] { (nint)0x01 };
        yield return new object[] { (nuint)0x01 };

        yield return new object[] { (float)0x01 };
        yield return new object[] { (double)0x01 };
        yield return new object[] { (decimal)0x01 };
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0230:Use UTF-8 string literal", Justification = "Not Dealing With Strings")]
    [Theory]
    [MemberData(nameof(GetData), parameters: false)]
    public void GetBytes_WhenNumberProvided_ReturnBytes<TNumberType>(TNumberType number) where TNumberType : INumberBase<TNumberType>
    {
        // Act
        var bytes = number.GetBytes();

        // Assert
        _ = typeof(TNumberType).Name switch
        {
            nameof(Byte) or nameof(SByte) => bytes.Should().Equal(0x01),
            nameof(Int16) or nameof(UInt16) => bytes.Should().Equal(0x01, 0x00),
            nameof(Int32) or nameof(UInt32) => bytes.Should().Equal(0x01, 0x00, 0x00, 0x00),
            nameof(Int64) or nameof(UInt64) => bytes.Should().Equal(0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00),
            nameof(IntPtr) or nameof(UIntPtr) when IntPtr.Size == 4 => bytes.Should().Equal(0x01, 0x00, 0x00, 0x00),
            nameof(IntPtr) or nameof(UIntPtr) when IntPtr.Size == 8 => bytes.Should().Equal(0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00),
            nameof(Single) => bytes.Should().Equal(0x00, 0x00, 0x80, 0x3F),
            nameof(Double) => bytes.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF0, 0x3F),
            nameof(Decimal) => bytes.Should().Equal(0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00),
            _ => null
        };
    }

    [Theory]
    [MemberData(nameof(GetData), parameters: true)]
    public void GetBytes_WhenNumberTypeNotSupported_ThrowNotSupportedException<TNumberType>(TNumberType number) where TNumberType : INumberBase<TNumberType>
    {
        //Act
        var bytes = () => number.GetBytes();

        //Assert
        _ = bytes.Should().Throw<NotSupportedException>().WithMessage($"There is no definition for getting bytes from a number of type '{typeof(TNumberType).Name}'");
    }

    [Theory]
    [MemberData(nameof(GetData), parameters: false)]
    public void GetBitsSize_WhenNumberProvided_ReturnBitsSize<TNumberType>(TNumberType number) where TNumberType : INumberBase<TNumberType>
    {
        // Act
        var bitsSize = number.GetBitsSize();

        // Assert
        _ = typeof(TNumberType).Name switch
        {
            nameof(Byte) or nameof(SByte) => bitsSize.Should().Be(8),
            nameof(Int16) or nameof(UInt16) => bitsSize.Should().Be(16),
            nameof(Int32) or nameof(UInt32) => bitsSize.Should().Be(32),
            nameof(Int64) or nameof(UInt64) => bitsSize.Should().Be(64),
            nameof(IntPtr) or nameof(UIntPtr) when IntPtr.Size == 4 => bitsSize.Should().Be(32),
            nameof(IntPtr) or nameof(UIntPtr) when IntPtr.Size == 8 => bitsSize.Should().Be(64),
            nameof(Single) => bitsSize.Should().Be(32),
            nameof(Double) => bitsSize.Should().Be(64),
            nameof(Decimal) => bitsSize.Should().Be(128),
            _ => null
        };
    }

    [Theory]
    [MemberData(nameof(GetData), parameters: true)]
    public void GetBitsSize_WhenNumberTypeNotSupported_ThrowNotSupportedException<TNumberType>(TNumberType number) where TNumberType : INumberBase<TNumberType>
    {
        //Act
        var bitsSize = () => number.GetBitsSize();

        //Assert
        _ = bitsSize.Should().Throw<NotSupportedException>().WithMessage($"There is no definition for getting the bits size from a number of type '{typeof(TNumberType).Name}'");
    }
}

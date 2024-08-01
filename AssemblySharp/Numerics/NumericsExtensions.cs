[assembly: InternalsVisibleTo("AssemblySharp.Tests")]

namespace System.Numerics;

internal static class NumericsExtensions
{
    public static byte[] GetBytes<TNumberType>(this TNumberType number) where TNumberType : INumberBase<TNumberType> => typeof(TNumberType).Name switch
    {
        _ when TNumberType.IsZero(number) => [],
        nameof(Byte) or nameof (SByte) => [byte.CreateChecked(number)],
        nameof(Int16) => BitConverter.GetBytes(short.CreateChecked(number)),
        nameof(UInt16) => BitConverter.GetBytes(ushort.CreateChecked(number)),
        nameof(Int32) => BitConverter.GetBytes(int.CreateChecked(number)),
        nameof(UInt32) => BitConverter.GetBytes(uint.CreateChecked(number)),
        nameof(Int64) => BitConverter.GetBytes(long.CreateChecked(number)),
        nameof(UInt64) => BitConverter.GetBytes(ulong.CreateChecked(number)),
        nameof(IntPtr) => BitConverter.GetBytes(nint.CreateChecked(number)),
        nameof(UIntPtr) => BitConverter.GetBytes(nuint.CreateChecked(number)),
        nameof(Single) => BitConverter.GetBytes(float.CreateChecked(number)),
        nameof(Double) => BitConverter.GetBytes(double.CreateChecked(number)),
        nameof(Decimal) => decimal.GetBits(decimal.CreateChecked(number)).SelectMany(BitConverter.GetBytes).ToArray(),
        _ => throw new NotSupportedException($"There is no definition for getting bytes from a number of type '{typeof(TNumberType).Name}'")
    };

    public static int GetBitsSize<TNumberType>(this TNumberType number) where TNumberType : INumberBase<TNumberType> => typeof(TNumberType).Name switch
    {
        nameof(Byte) or nameof (SByte) => sizeof(byte) * 8,
        nameof(Int16) or nameof(UInt16) => sizeof(short) * 8,
        nameof(Int32) or nameof(UInt32) => sizeof(int) * 8,
        nameof(Int64) or nameof(UInt64) => sizeof(long) * 8,
        nameof(IntPtr) => nint.Size * 8,
        nameof(UIntPtr) => nuint.Size * 8,
        nameof(Single) => sizeof(float) * 8,
        nameof(Double) => sizeof(double) * 8,
        nameof(Decimal) => sizeof(decimal) * 8,
        _ => throw new NotSupportedException($"There is no definition for getting the bits size from a number of type '{typeof(TNumberType).Name}'")
    };
}

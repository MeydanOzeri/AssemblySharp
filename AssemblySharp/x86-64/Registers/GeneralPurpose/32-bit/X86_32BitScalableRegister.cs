using AssemblySharp.Addressing;

namespace AssemblySharp.Registers.GeneralPurpose;

public class X86_32BitScalableRegister<T> : X86_32BitMemoryAddressableRegister<T> where T : IX86_32BitsGeneralPurposeRegister
{
    private X86_32BitScalableRegister(T register): base(register)
    {
    }

    public static implicit operator X86_32BitScalableRegister<T>(T register) => new(register);

    public static ScaledMemoryAddressing<X86_32BitMemoryAddressableRegisters, X86_32BitMemoryAddressableRegisters, int> operator *(X86_32BitScalableRegister<T> indexRegister, byte scale) => new() { Index = (dynamic)indexRegister, ScaleFactor = scale };
    public static ScaledMemoryAddressing<X86_32BitMemoryAddressableRegisters, X86_32BitMemoryAddressableRegisters, int> operator *(byte scale, X86_32BitScalableRegister<T> indexRegister) => indexRegister * scale;
}

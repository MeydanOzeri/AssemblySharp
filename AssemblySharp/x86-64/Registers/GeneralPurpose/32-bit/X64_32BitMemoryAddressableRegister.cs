using AssemblySharp.Addressing;

namespace AssemblySharp.Registers.GeneralPurpose;

public class X64_32BitMemoryAddressableRegister<T> : IX64_32BitsGeneralPurposeRegister where T : IX64_32BitsGeneralPurposeRegister
{
    private X64_32BitMemoryAddressableRegister(T register)
    {
        Name = register.Name;
        RegisterCode = register.RegisterCode;
    }

    public string Name { get; }
    public byte RegisterCode { get; }

    public static implicit operator X64_32BitMemoryAddressableRegister<T>(T register) => new(register);

    public static BaseMemoryAddressing<X64_32BitMemoryAddressableRegisters, X64_32BitMemoryAddressableRegisters, int> operator -(X64_32BitMemoryAddressableRegister<T> register, int displacement) => new() { Base = (dynamic)register, Displacement = -displacement };
    public static BaseMemoryAddressing<X64_32BitMemoryAddressableRegisters, X64_32BitMemoryAddressableRegisters, int> operator -(int displacement, X64_32BitMemoryAddressableRegister<T> register) => register - displacement;

    public static BaseMemoryAddressing<X64_32BitMemoryAddressableRegisters, X64_32BitMemoryAddressableRegisters, int> operator +(X64_32BitMemoryAddressableRegister<T> register, int displacement) => new() { Base = (dynamic)register, Displacement = displacement };
    public static BaseMemoryAddressing<X64_32BitMemoryAddressableRegisters, X64_32BitMemoryAddressableRegisters, int> operator +(int displacement, X64_32BitMemoryAddressableRegister<T> register) => register + displacement;

    public static ScaledMemoryAddressing<X64_32BitMemoryAddressableRegisters, X64_32BitMemoryAddressableRegisters, int> operator *(X64_32BitMemoryAddressableRegister<T> indexRegister, byte scale) => new() { Index = (dynamic)indexRegister, ScaleFactor = scale };
    public static ScaledMemoryAddressing<X64_32BitMemoryAddressableRegisters, X64_32BitMemoryAddressableRegisters, int> operator *(byte scale, X64_32BitMemoryAddressableRegister<T> indexRegister) => indexRegister * scale;

    public static BaseScaledMemoryAddressing<X64_32BitMemoryAddressableRegisters, X64_32BitMemoryAddressableRegisters, int> operator +(X64_32BitMemoryAddressableRegister<T> baseRegister, X64_32BitMemoryAddressableRegisters indexRegister) => new() { Base = (dynamic)baseRegister, Index = indexRegister };
}

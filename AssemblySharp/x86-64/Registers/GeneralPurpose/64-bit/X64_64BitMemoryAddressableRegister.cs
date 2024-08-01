using AssemblySharp.Addressing;

namespace AssemblySharp.Registers.GeneralPurpose;

public class X64_64BitMemoryAddressableRegister<T> : IX64_64BitsGeneralPurposeRegister where T : IX64_64BitsGeneralPurposeRegister
{
    private X64_64BitMemoryAddressableRegister(T register)
    {
        Name = register.Name;
        RegisterCode = register.RegisterCode;
    }

    public string Name { get; }
    public byte RegisterCode { get; }

    public static implicit operator X64_64BitMemoryAddressableRegister<T>(T register) => new(register);

    public static BaseMemoryAddressing<X64_64BitMemoryAddressableRegisters, X64_64BitMemoryAddressableRegisters, int> operator -(X64_64BitMemoryAddressableRegister<T> register, int displacement) => new() { Base = (dynamic)register, Displacement = -displacement };
    public static BaseMemoryAddressing<X64_64BitMemoryAddressableRegisters, X64_64BitMemoryAddressableRegisters, int> operator -(int displacement, X64_64BitMemoryAddressableRegister<T> register) => register - displacement;

    public static BaseMemoryAddressing<X64_64BitMemoryAddressableRegisters, X64_64BitMemoryAddressableRegisters, int> operator +(X64_64BitMemoryAddressableRegister<T> register, int displacement) => new() { Base = (dynamic)register, Displacement = displacement };
    public static BaseMemoryAddressing<X64_64BitMemoryAddressableRegisters, X64_64BitMemoryAddressableRegisters, int> operator +(int displacement, X64_64BitMemoryAddressableRegister<T> register) => register + displacement;

    public static ScaledMemoryAddressing<X64_64BitMemoryAddressableRegisters, X64_64BitMemoryAddressableRegisters, int> operator *(X64_64BitMemoryAddressableRegister<T> indexRegister, byte scale) => new() { Index = (dynamic)indexRegister, ScaleFactor = scale };
    public static ScaledMemoryAddressing<X64_64BitMemoryAddressableRegisters, X64_64BitMemoryAddressableRegisters, int> operator *(byte scale, X64_64BitMemoryAddressableRegister<T> indexRegister) => indexRegister * scale;

    public static BaseScaledMemoryAddressing<X64_64BitMemoryAddressableRegisters, X64_64BitMemoryAddressableRegisters, int> operator +(X64_64BitMemoryAddressableRegister<T> baseRegister, X64_64BitMemoryAddressableRegisters indexRegister) => new() { Base = (dynamic)baseRegister, Index = indexRegister };
}

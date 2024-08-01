using AssemblySharp.Addressing;

namespace AssemblySharp.Registers.GeneralPurpose;

public class X86_32BitMemoryAddressableRegister<T> : IX86_32BitsGeneralPurposeRegister where T : IX86_32BitsGeneralPurposeRegister
{
    protected X86_32BitMemoryAddressableRegister(T register)
    {
        Name = register.Name;
        RegisterCode = register.RegisterCode;
    }

    public string Name { get; }
    public byte RegisterCode { get; }

    public static implicit operator X86_32BitMemoryAddressableRegister<T>(T register) => new(register);

    public static BaseMemoryAddressing<X86_32BitMemoryAddressableRegisters, X86_32BitMemoryAddressableRegisters, int> operator -(X86_32BitMemoryAddressableRegister<T> register, int displacement) => new() { Base = (dynamic)register, Displacement = -displacement };
    public static BaseMemoryAddressing<X86_32BitMemoryAddressableRegisters, X86_32BitMemoryAddressableRegisters, int> operator -(int displacement, X86_32BitMemoryAddressableRegister<T> register) => register - displacement;

    public static BaseMemoryAddressing<X86_32BitMemoryAddressableRegisters, X86_32BitMemoryAddressableRegisters, int> operator +(X86_32BitMemoryAddressableRegister<T> register, int displacement) => new() { Base = (dynamic)register, Displacement = displacement };
    public static BaseMemoryAddressing<X86_32BitMemoryAddressableRegisters, X86_32BitMemoryAddressableRegisters, int> operator +(int displacement, X86_32BitMemoryAddressableRegister<T> register) => register + displacement;

    public static BaseScaledMemoryAddressing<X86_32BitMemoryAddressableRegisters, X86_32BitMemoryAddressableRegisters, int> operator +(X86_32BitMemoryAddressableRegister<T> baseRegister, X86_32BitMemoryAddressableRegisters indexRegister) => new() { Base = (dynamic)baseRegister, Index = indexRegister };
}

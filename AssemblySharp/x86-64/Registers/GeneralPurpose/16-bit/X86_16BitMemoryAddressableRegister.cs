using AssemblySharp.Addressing;

namespace AssemblySharp.Registers.GeneralPurpose;

public class X86_16BitMemoryAddressableRegister<T1, T2, T3, T4> : IX86_16BitsGeneralPurposeRegister
    where T1 : IX86_16BitsGeneralPurposeRegister
    where T2 : IX86_16BitsGeneralPurposeRegister
    where T3 : IX86_16BitsGeneralPurposeRegister
    where T4 : IX86_16BitsGeneralPurposeRegister
{
    private X86_16BitMemoryAddressableRegister(IX86_16BitsGeneralPurposeRegister register)
    {
        Name = register.Name;
        RegisterCode = register.RegisterCode;
    }

    public string Name { get; }
    public byte RegisterCode { get; set; }

    public static implicit operator X86_16BitMemoryAddressableRegister<T1, T2, T3, T4>(T1 register) => new(register);
    public static implicit operator X86_16BitMemoryAddressableRegister<T1, T2, T3, T4>(T2 register) => new(register);
    public static implicit operator X86_16BitMemoryAddressableRegister<T1, T2, T3, T4>(T3 register) => new(register);
    public static implicit operator X86_16BitMemoryAddressableRegister<T1, T2, T3, T4>(T4 register) => new(register);

    public static BaseMemoryAddressing<X86_16BitMemoryAddressableRegister<T1, T2, T3, T4>, X86_16BitMemoryAddressableRegister<T3, T4, T1, T2>, short> operator -(X86_16BitMemoryAddressableRegister<T1, T2, T3, T4> register, short displacement) => new() { Base = register, Displacement = (short)-displacement };
    public static BaseMemoryAddressing<X86_16BitMemoryAddressableRegister<T1, T2, T3, T4>, X86_16BitMemoryAddressableRegister<T3, T4, T1, T2>, short> operator -(short displacement, X86_16BitMemoryAddressableRegister<T1, T2, T3, T4> register) => register - displacement;

    public static BaseMemoryAddressing<X86_16BitMemoryAddressableRegister<T1, T2, T3, T4>, X86_16BitMemoryAddressableRegister<T3, T4, T1, T2>, short> operator +(X86_16BitMemoryAddressableRegister<T1, T2, T3, T4> register, short displacement) => new() { Base = register, Displacement = displacement };
    public static BaseMemoryAddressing<X86_16BitMemoryAddressableRegister<T1, T2, T3, T4>, X86_16BitMemoryAddressableRegister<T3, T4, T1, T2>, short> operator +(short displacement, X86_16BitMemoryAddressableRegister<T1, T2, T3, T4> register) => register + displacement;

    public static BaseScaledMemoryAddressing<X86_16BitMemoryAddressableRegister<T1, T2, T3, T4>, X86_16BitMemoryAddressableRegister<T3, T4, T1, T2>, short> operator +(X86_16BitMemoryAddressableRegister<T1, T2, T3, T4> baseRegister, X86_16BitMemoryAddressableRegister<T3, T4, T1, T2> indexRegister) => new() { Base = baseRegister, Index = indexRegister };

    public byte GetRmValue() => RegisterCode switch
    {
        var registerCode when registerCode == X86Registers.SI.RegisterCode => 0x04,
        var registerCode when registerCode == X86Registers.DI.RegisterCode => 0x05,
        var registerCode when registerCode == X86Registers.BP.RegisterCode => 0x06,
        var registerCode when registerCode == X86Registers.BX.RegisterCode => 0x07,
        _ => throw new NotImplementedException($"Register {Name} does not have an Rm value")
    };

    public byte GetRmValue(X86_16BitMemoryAddressableRegister<T1, T2, T3, T4> baseRegister) => true switch
    {
        true when baseRegister.RegisterCode == X86Registers.BX.RegisterCode && RegisterCode == X86Registers.SI.RegisterCode => 0x00,
        true when baseRegister.RegisterCode == X86Registers.BX.RegisterCode && RegisterCode == X86Registers.DI.RegisterCode => 0x01,
        true when baseRegister.RegisterCode == X86Registers.BP.RegisterCode && RegisterCode == X86Registers.SI.RegisterCode => 0x02,
        true when baseRegister.RegisterCode == X86Registers.BP.RegisterCode && RegisterCode == X86Registers.DI.RegisterCode => 0x03,
        _ => throw new NotImplementedException($"Register pair {baseRegister.Name} - {Name} does not have an Rm value")
    };

    public byte GetRmValue(X86_16BitMemoryAddressableRegister<T3, T4, T1, T2> indexRegister) => true switch
    {
        true when RegisterCode == X86Registers.BX.RegisterCode && indexRegister.RegisterCode == X86Registers.SI.RegisterCode => 0x00,
        true when RegisterCode == X86Registers.BX.RegisterCode && indexRegister.RegisterCode == X86Registers.DI.RegisterCode => 0x01,
        true when RegisterCode == X86Registers.BP.RegisterCode && indexRegister.RegisterCode == X86Registers.SI.RegisterCode => 0x02,
        true when RegisterCode == X86Registers.BP.RegisterCode && indexRegister.RegisterCode == X86Registers.DI.RegisterCode => 0x03,
        _ => throw new NotImplementedException($"Register pair {Name} - {indexRegister.Name} does not have an Rm value")
    };
}

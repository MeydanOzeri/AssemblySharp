using AssemblySharp.Registers.GeneralPurpose;
using AssemblySharp.Registers.Pointer;

namespace AssemblySharp.Registers;

public static class X86Registers
{
    public static IP IP => new();
    public static EIP EIP => new();
    public static RIP RIP => new();

    public static AH AH => new();
    public static AL AL => new();
    public static BH BH => new();
    public static BL BL => new();
    public static CH CH => new();
    public static CL CL => new();
    public static DH DH => new();
    public static DL DL => new();

    public static AX AX => new();
    public static X86_16BitMemoryAddressableRegister<BX, BP, SI, DI> BP => new BP();
    public static X86_16BitMemoryAddressableRegister<BX, BP, SI, DI> BX => new BX();
    public static CX CX => new();
    public static X86_16BitMemoryAddressableRegister<SI, DI, BX, BP> DI => new DI();
    public static DX DX => new();
    public static X86_16BitMemoryAddressableRegister<SI, DI, BX, BP> SI => new SI();
    public static SP SP => new();

    public static X86_32BitScalableRegister<EAX> EAX => new EAX();
    public static X86_32BitScalableRegister<EBP> EBP => new EBP();
    public static X86_32BitScalableRegister<EBX> EBX => new EBX();
    public static X86_32BitScalableRegister<ECX> ECX => new ECX();
    public static X86_32BitScalableRegister<EDI> EDI => new EDI();
    public static X86_32BitScalableRegister<EDX> EDX => new EDX();
    public static X86_32BitScalableRegister<ESI> ESI => new ESI();
    public static X86_32BitMemoryAddressableRegister<ESP> ESP => new ESP();
}

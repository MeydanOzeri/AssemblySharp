using AssemblySharp.Registers.GeneralPurpose;

namespace AssemblySharp.Registers;

public static class X64Registers
{
    public static SPL SPL => new();
    public static AL AL => new();
    public static DIL DIL => new();
    public static BL BL => new();
    public static BPL BPL => new();
    public static CL CL => new();
    public static SIL SIL => new();
    public static DL DL => new();
    public static R8B R8B => new();
    public static R9B R9B => new();
    public static R10B R10B => new();
    public static R11B R11B => new();
    public static R12B R12B => new();
    public static R13B R13B => new();
    public static R14B R14B => new();
    public static R15B R15B => new();

    public static AX AX => new();
    public static BP BP => new();
    public static BX BX => new();
    public static CX CX => new();
    public static DI DI => new();
    public static DX DX => new();
    public static SI SI => new();
    public static SP SP => new();
    public static R8W R8W => new();
    public static R9W R9W => new();
    public static R10W R10W => new();
    public static R11W R11W => new();
    public static R12W R12W => new();
    public static R13W R13W => new();
    public static R14W R14W => new();
    public static R15W R15W => new();

    public static X64_32BitMemoryAddressableRegister<EAX> EAX => new EAX();
    public static X64_32BitMemoryAddressableRegister<EBP> EBP => new EBP();
    public static X64_32BitMemoryAddressableRegister<EBX> EBX => new EBX();
    public static X64_32BitMemoryAddressableRegister<ECX> ECX => new ECX();
    public static X64_32BitMemoryAddressableRegister<EDI> EDI => new EDI();
    public static X64_32BitMemoryAddressableRegister<EDX> EDX => new EDX();
    public static X64_32BitMemoryAddressableRegister<ESI> ESI => new ESI();
    public static X64_32BitMemoryAddressableRegister<ESP> ESP => new ESP();
    public static X64_32BitMemoryAddressableRegister<R8D> R8D => new R8D();
    public static X64_32BitMemoryAddressableRegister<R9D> R9D => new R9D();
    public static X64_32BitMemoryAddressableRegister<R10D> R10D => new R10D();
    public static X64_32BitMemoryAddressableRegister<R11D> R11D => new R11D();
    public static X64_32BitMemoryAddressableRegister<R12D> R12D => new R12D();
    public static X64_32BitMemoryAddressableRegister<R13D> R13D => new R13D();
    public static X64_32BitMemoryAddressableRegister<R14D> R14D => new R14D();
    public static X64_32BitMemoryAddressableRegister<R15D> R15D => new R15D();

    public static X64_64BitMemoryAddressableRegister<RAX> RAX => new RAX();
    public static X64_64BitMemoryAddressableRegister<RBP> RBP => new RBP();
    public static X64_64BitMemoryAddressableRegister<RBX> RBX => new RBX();
    public static X64_64BitMemoryAddressableRegister<RCX> RCX => new RCX();
    public static X64_64BitMemoryAddressableRegister<RDI> RDI => new RDI();
    public static X64_64BitMemoryAddressableRegister<RDX> RDX => new RDX();
    public static X64_64BitMemoryAddressableRegister<RSI> RSI => new RSI();
    public static X64_64BitMemoryAddressableRegister<RSP> RSP => new RSP();
    public static X64_64BitMemoryAddressableRegister<R8> R8 => new R8();
    public static X64_64BitMemoryAddressableRegister<R9> R9 => new R9();
    public static X64_64BitMemoryAddressableRegister<R10> R10 => new R10();
    public static X64_64BitMemoryAddressableRegister<R11> R11 => new R11();
    public static X64_64BitMemoryAddressableRegister<R12> R12 => new R12();
    public static X64_64BitMemoryAddressableRegister<R13> R13 => new R13();
    public static X64_64BitMemoryAddressableRegister<R14> R14 => new R14();
    public static X64_64BitMemoryAddressableRegister<R15> R15 => new R15();
}

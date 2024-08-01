global using X86GeneralPurposeRegisters = AssemblySharp.Registers.Register
<
    AssemblySharp.Registers.GeneralPurpose.IX86_8BitsGeneralPurposeRegister,
    AssemblySharp.Registers.GeneralPurpose.IX86_16BitsGeneralPurposeRegister,
    AssemblySharp.Registers.GeneralPurpose.IX86_32BitsGeneralPurposeRegister
>;

global using X64GeneralPurposeRegisters = AssemblySharp.Registers.Register
<
    AssemblySharp.Registers.GeneralPurpose.IX64_8BitsGeneralPurposeRegister,
    AssemblySharp.Registers.GeneralPurpose.IX64_16BitsGeneralPurposeRegister,
    AssemblySharp.Registers.GeneralPurpose.IX64_32BitsGeneralPurposeRegister,
    AssemblySharp.Registers.GeneralPurpose.IX64_64BitsGeneralPurposeRegister
>;

global using X86_16BitMemoryAddressableRegister_A = AssemblySharp.Registers.GeneralPurpose.X86_16BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.BX, AssemblySharp.Registers.GeneralPurpose.BP, AssemblySharp.Registers.GeneralPurpose.SI, AssemblySharp.Registers.GeneralPurpose.DI>;
global using X86_16BitMemoryAddressableRegister_B = AssemblySharp.Registers.GeneralPurpose.X86_16BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.SI, AssemblySharp.Registers.GeneralPurpose.DI, AssemblySharp.Registers.GeneralPurpose.BX, AssemblySharp.Registers.GeneralPurpose.BP>;

global using X86_16BitMemoryAddressableRegisters = AssemblySharp.Registers.Register
<
    AssemblySharp.Registers.GeneralPurpose.X86_16BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.BX, AssemblySharp.Registers.GeneralPurpose.BP, AssemblySharp.Registers.GeneralPurpose.SI, AssemblySharp.Registers.GeneralPurpose.DI>,
    AssemblySharp.Registers.GeneralPurpose.X86_16BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.SI, AssemblySharp.Registers.GeneralPurpose.DI, AssemblySharp.Registers.GeneralPurpose.BX, AssemblySharp.Registers.GeneralPurpose.BP>
>;

global using X86_32BitMemoryAddressableRegisters = AssemblySharp.Registers.Register
<
    AssemblySharp.Registers.GeneralPurpose.X86_32BitScalableRegister<AssemblySharp.Registers.GeneralPurpose.EAX>,
    AssemblySharp.Registers.GeneralPurpose.X86_32BitScalableRegister<AssemblySharp.Registers.GeneralPurpose.EBP>,
    AssemblySharp.Registers.GeneralPurpose.X86_32BitScalableRegister<AssemblySharp.Registers.GeneralPurpose.EBX>,
    AssemblySharp.Registers.GeneralPurpose.X86_32BitScalableRegister<AssemblySharp.Registers.GeneralPurpose.ECX>,
    AssemblySharp.Registers.GeneralPurpose.X86_32BitScalableRegister<AssemblySharp.Registers.GeneralPurpose.EDI>,
    AssemblySharp.Registers.GeneralPurpose.X86_32BitScalableRegister<AssemblySharp.Registers.GeneralPurpose.EDX>,
    AssemblySharp.Registers.GeneralPurpose.X86_32BitScalableRegister<AssemblySharp.Registers.GeneralPurpose.ESI>,
    AssemblySharp.Registers.GeneralPurpose.X86_32BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.ESP>
>;

global using X64_32BitMemoryAddressableRegisters = AssemblySharp.Registers.Register
<
   AssemblySharp.Registers.GeneralPurpose.X64_32BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.EAX>,
   AssemblySharp.Registers.GeneralPurpose.X64_32BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.EBP>,
   AssemblySharp.Registers.GeneralPurpose.X64_32BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.EBX>,
   AssemblySharp.Registers.GeneralPurpose.X64_32BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.ECX>,
   AssemblySharp.Registers.GeneralPurpose.X64_32BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.EDI>,
   AssemblySharp.Registers.GeneralPurpose.X64_32BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.EDX>,
   AssemblySharp.Registers.GeneralPurpose.X64_32BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.ESI>,
   AssemblySharp.Registers.GeneralPurpose.X64_32BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.ESP>,
   AssemblySharp.Registers.GeneralPurpose.X64_32BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.R8D>,
   AssemblySharp.Registers.GeneralPurpose.X64_32BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.R9D>,
   AssemblySharp.Registers.GeneralPurpose.X64_32BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.R10D>,
   AssemblySharp.Registers.GeneralPurpose.X64_32BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.R11D>,
   AssemblySharp.Registers.GeneralPurpose.X64_32BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.R12D>,
   AssemblySharp.Registers.GeneralPurpose.X64_32BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.R13D>,
   AssemblySharp.Registers.GeneralPurpose.X64_32BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.R14D>,
   AssemblySharp.Registers.GeneralPurpose.X64_32BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.R15D>
>;

global using X64_64BitMemoryAddressableRegisters = AssemblySharp.Registers.Register
<
   AssemblySharp.Registers.GeneralPurpose.X64_64BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.RAX>,
   AssemblySharp.Registers.GeneralPurpose.X64_64BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.RBP>,
   AssemblySharp.Registers.GeneralPurpose.X64_64BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.RBX>,
   AssemblySharp.Registers.GeneralPurpose.X64_64BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.RCX>,
   AssemblySharp.Registers.GeneralPurpose.X64_64BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.RDI>,
   AssemblySharp.Registers.GeneralPurpose.X64_64BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.RDX>,
   AssemblySharp.Registers.GeneralPurpose.X64_64BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.RSI>,
   AssemblySharp.Registers.GeneralPurpose.X64_64BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.RSP>,
   AssemblySharp.Registers.GeneralPurpose.X64_64BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.R8>,
   AssemblySharp.Registers.GeneralPurpose.X64_64BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.R9>,
   AssemblySharp.Registers.GeneralPurpose.X64_64BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.R10>,
   AssemblySharp.Registers.GeneralPurpose.X64_64BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.R11>,
   AssemblySharp.Registers.GeneralPurpose.X64_64BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.R12>,
   AssemblySharp.Registers.GeneralPurpose.X64_64BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.R13>,
   AssemblySharp.Registers.GeneralPurpose.X64_64BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.R14>,
   AssemblySharp.Registers.GeneralPurpose.X64_64BitMemoryAddressableRegister<AssemblySharp.Registers.GeneralPurpose.R15>
>;

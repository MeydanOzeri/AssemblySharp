using AssemblySharp.Addressing;
using AssemblySharp.Registers;
using AssemblySharp.Registers.GeneralPurpose;

namespace AssemblySharp.X64;

public sealed class X64Assembler
{
    public X64Assembler Mov(IX64_8BitsGeneralPurposeRegister destination, IX64_8BitsGeneralPurposeRegister source) => this;
    public X64Assembler Mov(IX64_16BitsGeneralPurposeRegister destination, IX64_16BitsGeneralPurposeRegister source) => this;
    public X64Assembler Mov(IX64_32BitsGeneralPurposeRegister destination, IX64_32BitsGeneralPurposeRegister source) => this;
    public X64Assembler Mov(IX64_64BitsGeneralPurposeRegister destination, IX64_64BitsGeneralPurposeRegister source) => this;

    public X64Assembler Mov(X64GeneralPurposeRegisters destination, int[] source) => this;
    public X64Assembler Mov(int[] destination, X64GeneralPurposeRegisters source) => this;

    public X64Assembler Mov(X64_64BitMemoryAddressableRegister<RAX> destination, long[] source) => this;
    public X64Assembler Mov(long[] destination, X64_64BitMemoryAddressableRegister<RAX> source) => this;

    public X64Assembler Mov(X64GeneralPurposeRegisters destination, X64_32BitMemoryAddressableRegisters[] source) => this;
    public X64Assembler Mov(X64GeneralPurposeRegisters destination, X64_64BitMemoryAddressableRegisters[] source) => this;

    public X64Assembler Mov(X64_32BitMemoryAddressableRegisters[] destination, X64GeneralPurposeRegisters source) => this;
    public X64Assembler Mov(X64_64BitMemoryAddressableRegisters[] destination, X64GeneralPurposeRegisters source) => this;

    public X64Assembler Mov(X64GeneralPurposeRegisters destination, ImmediateAddressing<int>[] source) => this;
    public X64Assembler Mov(ImmediateAddressing<int>[] destination, X64GeneralPurposeRegisters source) => this;

    public byte[] Assemble() => throw new NotImplementedException();

    public void Test()
    {
        var (SPL, AL, DIL, BL, BPL, CL, SIL, DL) = (X64Registers.SPL, X64Registers.AL, X64Registers.DIL, X64Registers.BL, X64Registers.BPL, X64Registers.CL, X64Registers.SIL, X64Registers.DL);
        var (AX, BP, BX, CX, DI, DX, SI, SP) = (X64Registers.AX, X64Registers.BP, X64Registers.BX, X64Registers.CX, X64Registers.DI, X64Registers.DX, X64Registers.SI, X64Registers.SP);
        var (EAX, EBP, EBX, ECX, EDI, EDX, ESI, ESP) = (X64Registers.EAX, X64Registers.EBP, X64Registers.EBX, X64Registers.ECX, X64Registers.EDI, X64Registers.EDX, X64Registers.ESI, X64Registers.ESP);
        var (RAX, RBP, RBX, RCX, RDI, RDX, RSI, RSP) = (X64Registers.RAX, X64Registers.RBP, X64Registers.RBX, X64Registers.RCX, X64Registers.RDI, X64Registers.RDX, X64Registers.RSI, X64Registers.RSP);

        var bytes = new X64Assembler()
            // .Mov(AL, SPL)
            // .Mov(AX, BP)
            // .Mov(EAX, EBP)
            // .Mov(RAX, RBP)

            // .Mov(AL, [0x123])
            // .Mov(AX, [0x123])
            // .Mov(EAX, [0x123])
            // .Mov(RAX, [0x123])

            // .Mov(EAX, [EBP])
            // .Mov(RAX, [RBP])

            // .Mov(EAX, [EBP + 0x12])
            // .Mov(RAX, [RBP + 0x12])

            // .Mov(EAX, [EBP + EBX])
            // .Mov(RAX, [RBP + RBX])

            // .Mov(EAX, [EBP + EBX + 0x12])
            // .Mov(RAX, [RBP + RBX + 0x12])

            // .Mov(EAX, [(EBP + 0x12) + (EBX + 0x12)])
            // .Mov(RAX, [(RBP + 0x12) + (RBX + 0x12)])

            // .Mov(EAX, [EAX * 4])
            // .Mov(RAX, [RAX * 4])

            // .Mov(EAX, [EAX * 4 + 0x12])
            // .Mov(RAX, [RAX * 4 + 0x12])

            // .Mov(EAX, [EDX * 4 + EAX])
            // .Mov(RAX, [RDX * 4 + RAX])

            // .Mov(EAX, [(EDX * 4) + (EAX + 0x12)])
            // .Mov(RAX, [(RDX * 4) + (RAX + 0x12)])

            // .Mov(EAX, [EAX * 4 + 0x12 + EDX])
            // .Mov(RAX, [RAX * 4 + 0x12 + RDX])

            // .Mov(EAX, [EDX + EAX * 4])
            // .Mov(RAX, [RDX + RAX * 4])

            // .Mov(EAX, [EDX + EAX * 4 + 0x12])
            // .Mov(RAX, [RDX + RAX * 4 + 0x12])

            // .Mov(EAX, [EDX + 0x12 + EAX * 4])
            // .Mov(RAX, [RDX + 0x12 + RAX * 4])

            .Assemble();
    }
}

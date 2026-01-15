// See https://aka.ms/new-console-template for more information
using AssemblySharp.Registers;
using AssemblySharp.X86;

static void Test()
{
	var (AH, AL, BH, BL, CH, CL, DH, DL) = (X86Registers.AH, X86Registers.AL, X86Registers.BH, X86Registers.BL, X86Registers.CH, X86Registers.CL, X86Registers.DH, X86Registers.DL);
	var (AX, BP, BX, CX, DI, DX, SI, SP) = (X86Registers.AX, X86Registers.BP, X86Registers.BX, X86Registers.CX, X86Registers.DI, X86Registers.DX, X86Registers.SI, X86Registers.SP);
	var (EAX, EBP, EBX, ECX, EDI, EDX, ESI, ESP) = (
		X86Registers.EAX,
		X86Registers.EBP,
		X86Registers.EBX,
		X86Registers.ECX,
		X86Registers.EDI,
		X86Registers.EDX,
		X86Registers.ESI,
		X86Registers.ESP
	);

	var bytes = new X86Assembler()
		// .Mov(AL, AH)

		// .Mov([0x123], AH)

		// .Mov([BX], AH)
		// .Mov([SI], AH)

		// .Mov([EBP], AH)

		// .Mov([EAX * 1 + ESP], AH)
		// .Mov([SI + 0x12], AH)

		// .Mov([EBP + 0x12], AH)

		// .Mov([EAX * 4], AH)
		// .Mov([EAX * 4 + 0x12], AH)

		// .Mov([BX + SI + 1], AH)
		// .Mov([SI + BX], AH)

		// .Mov([EBP + EBX], AH)

		// .Mov([BX + SI + 0x12], AH)
		// .Mov([SI + BX + 0x12], AH)

		// .Mov([EBP + EBX + 0x12], AH)

		// .Mov([(BX + 0x12) + (SI + 0x12)], AH)
		// .Mov([(SI + 0x12) + (BX + 0x12)], AH)

		// .Mov([(EBP + 0x12) + (EBX + 0x12)], AH)

		// .Mov([EDX * 4 + EAX], AH)
		// .Mov([(EDX * 4) + (EAX + 0x12)], AH)
		// .Mov([EAX * 4 + 0x12 + EDX], AH)
		// .Mov([EDX + EAX * 4], AH)
		// .Mov([EDX + EAX * 4 + 0x12], AH)

		.Mov([EDX + 0x12 + EAX * 4], AH)
		.Assemble();
	Console.WriteLine(BitConverter.ToString(bytes));
}

Test();

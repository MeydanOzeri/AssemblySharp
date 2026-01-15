using AssemblySharp.Addressing;
using AssemblySharp.Prefixes.Legacy;
using AssemblySharp.Registers;
using AssemblySharp.Registers.GeneralPurpose;

namespace AssemblySharp.X86;

// internal static class X86_Mov
// {
//     private static byte GetMovOpcode() => true switch
//     {
//         _ => throw new NotImplementedException()
//     };

//     public static X86Instruction Create(X86GeneralPurposeRegisters registerMemory, X86GeneralPurposeRegisters register)
//     {
//         var opcode = [];
//         return new()
//         {
//             Opcode = opcode,
//             ModRM = new() { Mod = ModType.REGISTER_DIRECT_ADDRESSING_MODE, Rm = registerMemory.RegisterCode, Reg = register.RegisterCode }
//         };
//     }
//     public static X86Instruction Create<T>(ImmediateAddressing<T> registerMemory, X86GeneralPurposeRegisters register) where T : ISignedNumber<T>
//     {
//         // except AL/AX/EAX/RAX registers
//         var opcode = [];
//         return new()
//         {
//             Opcode = opcode,
//             ModRM = new() { Mod = ModType.MEMORY_ADDRESSING_MODE, Rm = X86Registers.EIP.RegisterCode, Reg = register.RegisterCode },
//             Displacement = registerMemory.Displacement.GetBytes()
//         };
//     }
// }

internal static class X86_RM8_R8_Mov
{
	private const byte RM8_R8_OPCODE = 0x88;

	public static X86Instruction Create(IX86_8BitsGeneralPurposeRegister rm8, IX86_8BitsGeneralPurposeRegister r8) =>
		new()
		{
			Opcode = [RM8_R8_OPCODE],
			ModRM = new()
			{
				Mod = ModType.REGISTER_DIRECT_ADDRESSING_MODE,
				Rm = rm8.RegisterCode,
				Reg = r8.RegisterCode,
			},
		};

	public static X86Instruction Create(ImmediateAddressing<int> rm8, IX86_8BitsGeneralPurposeRegister r8) =>
		new()
		{
			// except AL/AX/EAX/RAX registers
			Opcode = [RM8_R8_OPCODE],
			ModRM = new()
			{
				Mod = ModType.MEMORY_ADDRESSING_MODE,
				Rm = X86Registers.EIP.RegisterCode,
				Reg = r8.RegisterCode,
			},
			Displacement = rm8.Displacement.GetBytes(),
		};

	public static X86Instruction Create<T1, T2, T3, T4>(
		BaseMemoryAddressing<X86_16BitMemoryAddressableRegister<T1, T2, T3, T4>, X86_16BitMemoryAddressableRegister<T3, T4, T1, T2>, short> rm8,
		IX86_8BitsGeneralPurposeRegister r8
	)
		where T1 : IX86_16BitsGeneralPurposeRegister
		where T2 : IX86_16BitsGeneralPurposeRegister
		where T3 : IX86_16BitsGeneralPurposeRegister
		where T4 : IX86_16BitsGeneralPurposeRegister
	{
		var displacement = rm8.Displacement is <= sbyte.MaxValue and >= sbyte.MinValue ? ((sbyte)rm8.Displacement).GetBytes() : rm8.Displacement.GetBytes();
		var isBPRegisterWithoutDisplacement = rm8.Base.RegisterCode == X86Registers.BP.RegisterCode && displacement.Length == 0;
		return new()
		{
			AddressSizeOverride = AddressSizeOverride.ADDRESS_SIZE_OVERRIDE,
			Opcode = [RM8_R8_OPCODE],
			ModRM = new()
			{
				Mod = isBPRegisterWithoutDisplacement ? ModType.ONE_BYTE_SIGNED_DISPLACEMENT : ModRM.GetModType(displacement),
				Rm = rm8.Base.GetRmValue(),
				Reg = r8.RegisterCode,
			},
			Displacement = isBPRegisterWithoutDisplacement ? [0x00] : displacement,
		};
	}

	public static X86Instruction Create(
		BaseMemoryAddressing<X86_32BitMemoryAddressableRegisters, X86_32BitMemoryAddressableRegisters, int> rm8,
		IX86_8BitsGeneralPurposeRegister r8
	)
	{
		var displacement = rm8.Displacement is <= sbyte.MaxValue and >= sbyte.MinValue ? ((sbyte)rm8.Displacement).GetBytes() : rm8.Displacement.GetBytes();
		var isEBPRegisterWithoutDisplacement = rm8.Base.RegisterCode == X86Registers.EBP.RegisterCode && displacement.Length == 0;
		return new()
		{
			Opcode = [RM8_R8_OPCODE],
			ModRM = new()
			{
				Mod = isEBPRegisterWithoutDisplacement ? ModType.ONE_BYTE_SIGNED_DISPLACEMENT : ModRM.GetModType(displacement),
				Rm = rm8.Base.RegisterCode,
				Reg = r8.RegisterCode,
			},
			Sib =
				rm8.Base.RegisterCode == X86Registers.ESP.RegisterCode
					? new()
					{
						Scale = ScaleFactor.One,
						Index = rm8.Base.RegisterCode,
						Base = rm8.Base.RegisterCode,
					}
					: null,
			Displacement = isEBPRegisterWithoutDisplacement ? [0x00] : displacement,
		};
	}

	public static X86Instruction Create<TIndex, TAllowedBase>(ScaledMemoryAddressing<TIndex, TAllowedBase, int> rm8, IX86_8BitsGeneralPurposeRegister r8)
		where TIndex : IRegister
		where TAllowedBase : IRegister
	{
		var displacement = rm8.Displacement.GetBytes();
		return new()
		{
			Opcode = [RM8_R8_OPCODE],
			ModRM = new()
			{
				Mod = ModType.MEMORY_ADDRESSING_MODE,
				Rm = X86Registers.ESP.RegisterCode,
				Reg = r8.RegisterCode,
			},
			Sib = new()
			{
				Scale = Sib.GetScaleFactor(rm8.ScaleFactor),
				Index = rm8.Index.RegisterCode,
				Base = X86Registers.EBP.RegisterCode,
			},
			Displacement = displacement.Length > 0 ? displacement : [0x00, 0x00, 0x00, 0x00],
		};
	}

	public static X86Instruction Create<T1, T2, T3, T4>(
		BaseScaledMemoryAddressing<X86_16BitMemoryAddressableRegister<T1, T2, T3, T4>, X86_16BitMemoryAddressableRegister<T3, T4, T1, T2>, short> rm8,
		IX86_8BitsGeneralPurposeRegister r8
	)
		where T1 : IX86_16BitsGeneralPurposeRegister
		where T2 : IX86_16BitsGeneralPurposeRegister
		where T3 : IX86_16BitsGeneralPurposeRegister
		where T4 : IX86_16BitsGeneralPurposeRegister
	{
		var displacement = rm8.Displacement is <= sbyte.MaxValue and >= sbyte.MinValue ? ((sbyte)rm8.Displacement).GetBytes() : rm8.Displacement.GetBytes();
		return new()
		{
			AddressSizeOverride = AddressSizeOverride.ADDRESS_SIZE_OVERRIDE,
			Opcode = [RM8_R8_OPCODE],
			ModRM = new()
			{
				Mod = ModRM.GetModType(displacement),
				Rm = rm8.Base.GetRmValue(rm8.Index),
				Reg = r8.RegisterCode,
			},
			Displacement = displacement,
		};
	}

	public static X86Instruction Create(
		BaseScaledMemoryAddressing<X86_32BitMemoryAddressableRegisters, X86_32BitMemoryAddressableRegisters, int> rm8,
		IX86_8BitsGeneralPurposeRegister r8
	)
	{
		var displacement = rm8.Displacement is <= sbyte.MaxValue and >= sbyte.MinValue ? ((sbyte)rm8.Displacement).GetBytes() : rm8.Displacement.GetBytes();
		var displacementBytes = displacement.Length == 0 && rm8.Base.RegisterCode == X86Registers.EBP.RegisterCode ? [0x00] : displacement;
		return new()
		{
			Opcode = [RM8_R8_OPCODE],
			ModRM = new()
			{
				Mod = ModRM.GetModType(displacementBytes),
				Rm = X86Registers.ESP.RegisterCode,
				Reg = r8.RegisterCode,
			},
			Sib = new()
			{
				Scale = Sib.GetScaleFactor(rm8.ScaleFactor),
				Index = rm8.Index.RegisterCode,
				Base = rm8.Base.RegisterCode,
			},
			Displacement = displacementBytes,
		};
	}
}

internal static class X86_RM16_R16_Mov
{
	private const byte R16_RM16_OPCODE = 0x89;

	public static X86Instruction Create(IX86_16BitsGeneralPurposeRegister rm8, IX86_16BitsGeneralPurposeRegister r8) =>
		new()
		{
			Opcode = [R16_RM16_OPCODE],
			ModRM = new()
			{
				Mod = ModType.REGISTER_DIRECT_ADDRESSING_MODE,
				Rm = rm8.RegisterCode,
				Reg = r8.RegisterCode,
			},
		};
}

internal static class X86_RM32_R32_Mov
{
	private const byte R32_RM32_OPCODE = 0x89;

	public static X86Instruction Create(IX86_32BitsGeneralPurposeRegister rm8, IX86_32BitsGeneralPurposeRegister r8) =>
		new()
		{
			Opcode = [R32_RM32_OPCODE],
			ModRM = new()
			{
				Mod = ModType.REGISTER_DIRECT_ADDRESSING_MODE,
				Rm = rm8.RegisterCode,
				Reg = r8.RegisterCode,
			},
		};
}

public sealed class X86Assembler
{
	private readonly List<X86Instruction> _instructions = [];

	public X86Assembler Mov(IX86_8BitsGeneralPurposeRegister destination, IX86_8BitsGeneralPurposeRegister source)
	{
		_instructions.Add(X86_RM8_R8_Mov.Create(destination, source));
		return this;
	}

	public X86Assembler Mov(IMemoryAddressing[] destination, IX86_8BitsGeneralPurposeRegister source)
	{
		var memoryAddressing = destination.Single();
		var instruction = memoryAddressing switch
		{
			ImmediateAddressing<int> immediateAddressing => X86_RM8_R8_Mov.Create(immediateAddressing, source),
			BaseMemoryAddressing<X86_16BitMemoryAddressableRegister_A, X86_16BitMemoryAddressableRegister_B, short> baseMemoryAddressing => X86_RM8_R8_Mov.Create(
				baseMemoryAddressing,
				source
			),
			BaseMemoryAddressing<X86_16BitMemoryAddressableRegister_B, X86_16BitMemoryAddressableRegister_A, short> baseMemoryAddressing => X86_RM8_R8_Mov.Create(
				baseMemoryAddressing,
				source
			),
			BaseMemoryAddressing<X86_32BitMemoryAddressableRegisters, X86_32BitMemoryAddressableRegisters, int> baseMemoryAddressing => X86_RM8_R8_Mov.Create(
				baseMemoryAddressing,
				source
			),
			ScaledMemoryAddressing<X86_32BitMemoryAddressableRegisters, X86_32BitMemoryAddressableRegisters, int> scaledMemoryAddressing => X86_RM8_R8_Mov.Create(
				scaledMemoryAddressing,
				source
			),
			BaseScaledMemoryAddressing<X86_16BitMemoryAddressableRegister_A, X86_16BitMemoryAddressableRegister_B, short> baseScaledMemoryAddressing => X86_RM8_R8_Mov.Create(
				baseScaledMemoryAddressing,
				source
			),
			BaseScaledMemoryAddressing<X86_16BitMemoryAddressableRegister_B, X86_16BitMemoryAddressableRegister_A, short> baseScaledMemoryAddressing => X86_RM8_R8_Mov.Create(
				baseScaledMemoryAddressing,
				source
			),
			BaseScaledMemoryAddressing<X86_32BitMemoryAddressableRegisters, X86_32BitMemoryAddressableRegisters, int> baseScaledMemoryAddressing => X86_RM8_R8_Mov.Create(
				baseScaledMemoryAddressing,
				source
			),
			_ => throw new NotImplementedException($"Unsupported memory addressing '{memoryAddressing.GetType().Name}'"),
		};
		_instructions.Add(instruction);
		return this;
	}

	public X86Assembler Mov(int[] destination, IX86_8BitsGeneralPurposeRegister source)
	{
		var immediateMemoryAddressing = new ImmediateAddressing<int>() { Displacement = destination.Single() };
		return Mov([immediateMemoryAddressing], source);
	}

	public X86Assembler Mov<T1, T2, T3, T4>(X86_16BitMemoryAddressableRegister<T1, T2, T3, T4>[] destination, IX86_8BitsGeneralPurposeRegister source)
		where T1 : IX86_16BitsGeneralPurposeRegister
		where T2 : IX86_16BitsGeneralPurposeRegister
		where T3 : IX86_16BitsGeneralPurposeRegister
		where T4 : IX86_16BitsGeneralPurposeRegister
	{
		var baseMemoryAddressing = new BaseMemoryAddressing<X86_16BitMemoryAddressableRegister<T1, T2, T3, T4>, X86_16BitMemoryAddressableRegister<T3, T4, T1, T2>, short>()
		{
			Base = destination.Single(),
		};
		return Mov([baseMemoryAddressing], source);
	}

	public X86Assembler Mov(X86_32BitMemoryAddressableRegisters[] destination, IX86_8BitsGeneralPurposeRegister source)
	{
		var baseMemoryAddressing = new BaseMemoryAddressing<X86_32BitMemoryAddressableRegisters, X86_32BitMemoryAddressableRegisters, int>() { Base = destination.Single() };
		return Mov([baseMemoryAddressing], source);
	}

	public byte[] Assemble() => [.. _instructions.SelectMany(instruction => instruction.Encode())];
}

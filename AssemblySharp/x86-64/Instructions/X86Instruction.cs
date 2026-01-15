using AssemblySharp.Addressing;
using AssemblySharp.Prefixes.Legacy;
using AssemblySharp.Prefixes.Opcode;

namespace AssemblySharp.X86;

internal class X86Instruction
{
	public LockAndRepeat? LockAndRepeat { get; init; }
	public SegmentOverride? SegmentOverride { get; init; }
	public OperandSizeOverride? OperandSizeOverride { get; init; }
	public AddressSizeOverride? AddressSizeOverride { get; init; }
	public OpcodeExtension? OpcodeExtension { get; init; }

	public required byte[] Opcode
	{
		get;
		init => field = value.Length <= 3 ? value : throw new InvalidOperationException("Opcode cannot have more than 3 bytes in the x86 architecture");
	}

	public ModRM? ModRM { get; init; }

	public Sib? Sib { get; init; }

	public byte[]? Displacement
	{
		get;
		init => field = value?.Length <= 4 ? value : throw new InvalidOperationException("Displacement cannot be bigger than a 32-bit value in the x86 architecture");
	}

	public byte[]? Immediate
	{
		get;
		init => field = value?.Length <= 4 ? value : throw new InvalidOperationException("Immediate cannot be bigger than a 32-bit value in the x86 architecture");
	}

	public byte[] Encode()
	{
		var instructionBytes = new List<byte>();
		if (LockAndRepeat.HasValue)
		{
			instructionBytes.Add((byte)LockAndRepeat.Value);
		}
		if (SegmentOverride.HasValue)
		{
			instructionBytes.Add((byte)SegmentOverride.Value);
		}
		if (OperandSizeOverride.HasValue)
		{
			instructionBytes.Add((byte)OperandSizeOverride.Value);
		}
		if (AddressSizeOverride.HasValue)
		{
			instructionBytes.Add((byte)AddressSizeOverride.Value);
		}
		if (OpcodeExtension.HasValue)
		{
			instructionBytes.Add((byte)OpcodeExtension.Value);
		}
		instructionBytes.AddRange(Opcode);
		if (ModRM.HasValue)
		{
			instructionBytes.Add(ModRM.Value.Encode());
		}
		if (Sib.HasValue)
		{
			instructionBytes.Add(Sib.Value.Encode());
		}
		if (Displacement is not null)
		{
			instructionBytes.AddRange(Displacement);
		}
		if (Immediate is not null)
		{
			instructionBytes.AddRange(Immediate);
		}
		return [.. instructionBytes];
	}
}

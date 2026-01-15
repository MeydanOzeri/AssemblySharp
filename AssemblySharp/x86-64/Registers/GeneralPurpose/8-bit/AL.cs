namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which represents the lower byte of the AX register, (Accumulator Register) used for accumulating operands and results data.
/// </summary>
public sealed class AL : IX86_8BitsGeneralPurposeRegister, IX64_8BitsGeneralPurposeRegister
{
	public string Name => nameof(AL);
	public byte RegisterCode => 0x00;
}

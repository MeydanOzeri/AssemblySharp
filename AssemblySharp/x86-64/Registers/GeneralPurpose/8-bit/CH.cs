namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which represents the higher byte of the CX register, (Count Register) not available in x64 mode, used as a counter for string and loop operations.
/// </summary>
public sealed class CH : IX86_8BitsGeneralPurposeRegister
{
	public string Name => nameof(CH);
	public byte RegisterCode => 0x05;
}

namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Extended Count Register" (extends the 16-bit CX register into 32-bit), used as a counter for string and loop operations.
/// </summary>
public class ECX : IX86_32BitsGeneralPurposeRegister, IX64_32BitsGeneralPurposeRegister
{
	public string Name => nameof(ECX);
	public byte RegisterCode => 0x01;
}

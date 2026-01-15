namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which represents the lower byte of the DX register, (Data Register) used to point to data in I/O operations
/// </summary>
public sealed class DL : IX86_8BitsGeneralPurposeRegister, IX64_8BitsGeneralPurposeRegister
{
	public string Name => nameof(DL);
	public byte RegisterCode => 0x02;
}

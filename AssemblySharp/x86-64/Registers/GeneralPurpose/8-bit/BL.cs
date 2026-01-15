namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which represents the lower byte of the BX register, (Base Register) points to data in the DS segment (Data Segment).
/// </summary>
public sealed class BL : IX86_8BitsGeneralPurposeRegister, IX64_8BitsGeneralPurposeRegister
{
	public string Name => nameof(BL);
	public byte RegisterCode => 0x03;
}

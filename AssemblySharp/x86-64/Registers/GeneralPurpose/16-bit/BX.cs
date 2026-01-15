namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Base Register" (extends the 8-bit BH and BL registers into 16-bit), points to data in the DS segment (Data Segment).
/// </summary>
public class BX : IX86_16BitsGeneralPurposeRegister, IX64_16BitsGeneralPurposeRegister
{
	public string Name => nameof(BX);
	public byte RegisterCode => 0x03;
}

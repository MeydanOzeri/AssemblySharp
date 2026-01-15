namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Extended Base Register" (extends the 16-bit BX register into 32-bit), points to data in the DS segment (Data Segment).
/// </summary>
public class EBX : IX86_32BitsGeneralPurposeRegister, IX64_32BitsGeneralPurposeRegister
{
	public string Name => nameof(EBX);
	public byte RegisterCode => 0x03;
}

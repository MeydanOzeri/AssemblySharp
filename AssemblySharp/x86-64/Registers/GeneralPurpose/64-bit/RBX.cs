namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Base Register" (extends the 32-bit EBX register into 64-bit), points to data in the DS segment (Data Segment).
/// </summary>
public class RBX : IX64_64BitsGeneralPurposeRegister
{
	public string Name => nameof(RBX);
	public byte RegisterCode => 0x03;
}

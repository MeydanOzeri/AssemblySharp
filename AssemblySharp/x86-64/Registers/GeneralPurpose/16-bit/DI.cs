namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Destination Index", used as a pointer to data in the "Data Segment" (DS segment) usually used to point to the end of arrays/string/objects.
/// </summary>
public class DI : IX86_16BitsGeneralPurposeRegister, IX64_16BitsGeneralPurposeRegister
{
	public string Name => nameof(DI);
	public byte RegisterCode => 0x07;
}

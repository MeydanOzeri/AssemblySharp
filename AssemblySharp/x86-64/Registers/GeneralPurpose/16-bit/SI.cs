namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Source Index", used as a pointer to data in the "Data Segment" (DS segment) usually used to point to the beginning of arrays/string/objects.
/// </summary>
public class SI : IX86_16BitsGeneralPurposeRegister, IX64_16BitsGeneralPurposeRegister
{
	public string Name => nameof(SI);
	public byte RegisterCode => 0x06;
}

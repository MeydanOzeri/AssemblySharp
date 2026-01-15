namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Destination Index", (extends the 32-bit EDI register into 64-bit) used as a pointer to data in the "Data Segment" (DS segment) usually used to point to the end of arrays/string/objects.
/// </summary>
public class RDI : IX64_64BitsGeneralPurposeRegister
{
	public string Name => nameof(RDI);
	public byte RegisterCode => 0x07;
}

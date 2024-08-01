namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Extended Source Index", (extends the 16-bit SI register into 32-bit) used as a pointer to data in the "Data Segment" (DS segment) usually used to point to the beginning of arrays/string/objects.
/// </summary>
public class ESI : IX86_32BitsGeneralPurposeRegister, IX64_32BitsGeneralPurposeRegister
{
    public string Name => nameof(ESI);
    public byte RegisterCode => 0x06;
}

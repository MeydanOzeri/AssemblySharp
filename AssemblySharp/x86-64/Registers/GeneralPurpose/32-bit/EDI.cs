namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Extended Destination Index", (extends the 16-bit DI register into 32-bit) used as a pointer to data in the "Data Segment" (DS segment) usually used to point to the end of arrays/string/objects.
/// </summary>
public class EDI : IX86_32BitsGeneralPurposeRegister, IX64_32BitsGeneralPurposeRegister
{
    public string Name => nameof(EDI);
    public byte RegisterCode => 0x07;
}

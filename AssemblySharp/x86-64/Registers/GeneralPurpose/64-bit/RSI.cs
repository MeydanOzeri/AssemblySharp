namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Source Index", (extends the 32-bit ESI register into 64-bit) used as a pointer to data in the "Data Segment" (DS segment) usually used to point to the beginning of arrays/string/objects.
/// </summary>
public class RSI : IX64_64BitsGeneralPurposeRegister
{
    public string Name => nameof(RSI);
    public byte RegisterCode => 0x06;
}

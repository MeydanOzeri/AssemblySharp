namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which represents the lower byte of the SI register, (Source Index) used as a pointer to data in the "Data Segment" (DS segment) usually used to point to the beginning of arrays/string/objects. (only available in x64 mode)
/// </summary>
public sealed class SIL : IX64_8BitsGeneralPurposeRegister
{
    public string Name => nameof(SIL);
    public byte RegisterCode => 0x06;
}

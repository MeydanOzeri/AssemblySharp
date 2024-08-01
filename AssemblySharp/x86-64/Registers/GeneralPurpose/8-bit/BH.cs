namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which represents the higher byte of the BX register, (Base Register) not available in x64 mode, points to data in the DS segment (Data Segment).
/// </summary>
public sealed class BH : IX86_8BitsGeneralPurposeRegister
{
    public string Name => nameof(BH);
    public byte RegisterCode => 0x07;
}

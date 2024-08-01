namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which represents the lower byte of the CX register, (Count Register) used as a counter for string and loop operations
/// </summary>
public sealed class CL : IX86_8BitsGeneralPurposeRegister, IX64_8BitsGeneralPurposeRegister
{
    public string Name => nameof(CL);
    public byte RegisterCode => 0x01;
}

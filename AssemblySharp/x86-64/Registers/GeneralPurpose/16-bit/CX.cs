namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Count Register" (extends the 8-bit CH and CL registers into 16-bit), used as a counter for string and loop operations.
/// </summary>
public class CX : IX86_16BitsGeneralPurposeRegister, IX64_16BitsGeneralPurposeRegister
{
    public string Name => nameof(CX);
    public byte RegisterCode => 0x01;
}

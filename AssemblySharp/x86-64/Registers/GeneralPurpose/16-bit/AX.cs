namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Accumulator Register" (extends the 8-bit AH and AL registers into 16-bit), used for accumulating operands and results data.
/// </summary>
public class AX : IX86_16BitsGeneralPurposeRegister, IX64_16BitsGeneralPurposeRegister
{
    public string Name => nameof(AX);
    public byte RegisterCode => 0x00;
}

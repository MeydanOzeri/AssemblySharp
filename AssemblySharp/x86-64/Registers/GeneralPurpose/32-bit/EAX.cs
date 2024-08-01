namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Extended Accumulator Register" (extends the 16-bit AX register into 32-bit), used for accumulating operands and results data.
/// </summary>
public class EAX : IX86_32BitsGeneralPurposeRegister, IX64_32BitsGeneralPurposeRegister
{
    public string Name => nameof(EAX);
    public byte RegisterCode => 0x00;
}

namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which represents the higher byte of the AX register, (Accumulator Register) not available in x64 mode, used for accumulating operands and results data.
/// </summary>
public sealed class AH : IX86_8BitsGeneralPurposeRegister
{
    public string Name => nameof(AH);
    public byte RegisterCode => 0x04;
}

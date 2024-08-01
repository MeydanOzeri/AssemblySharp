namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Accumulator Register" (extends the 32-bit EAX register into 64-bit), used for accumulating operands and results data.
/// </summary>
public class RAX : IX64_64BitsGeneralPurposeRegister
{
    public string Name => nameof(RAX);
    public byte RegisterCode => 0x00;
}

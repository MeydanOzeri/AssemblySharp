namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Count Register" (extends the 32-bit ECX register into 64-bit), used as a counter for string and loop operations.
/// </summary>
public class RCX : IX64_64BitsGeneralPurposeRegister
{
    public string Name => nameof(RCX);
    public byte RegisterCode => 0x01;
}

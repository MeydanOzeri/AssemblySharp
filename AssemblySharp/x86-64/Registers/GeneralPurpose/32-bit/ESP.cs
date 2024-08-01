namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Extended Stack Pointer", (extends the 16-bit SP register into 32-bit) points to the topmost item of the stack (in the SS segment or "Stack Segment").
/// </summary>
public class ESP : IX86_32BitsGeneralPurposeRegister, IX64_32BitsGeneralPurposeRegister
{
    public string Name => nameof(ESP);
    public byte RegisterCode => 0x04;
}

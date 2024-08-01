namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which represents the lower byte of the SP register, (Stack Pointer) points to the topmost item of the stack. (in the SS segment or "Stack Segment")(only available in x64 mode)
/// </summary>
public sealed class SPL : IX64_8BitsGeneralPurposeRegister
{
    public string Name => nameof(SPL);
    public byte RegisterCode => 0x04;
}

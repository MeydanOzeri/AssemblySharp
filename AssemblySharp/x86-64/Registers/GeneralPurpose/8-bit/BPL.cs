namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which represents the lower byte of the BP register, (Base Pointer) points to the beginning of the data on the stack (in the SS segment or "Stack Segment"). (only available in x64 mode)
/// </summary>
public sealed class BPL : IX64_8BitsGeneralPurposeRegister
{
    public string Name => nameof(BPL);
    public byte RegisterCode => 0x05;
}

namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called R10D (extends the 16-bit R10W into 32-bit), doesn't have a dedicated role, can be used for any operation. (only available in x64 mode)
/// </summary>
public class R10D : IX64_32BitsGeneralPurposeRegister
{
    public string Name => nameof(R10D);
    public byte RegisterCode => 0x0A;
}

namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called R14D (extends the 16-bit R14W into 32-bit), doesn't have a dedicated role, can be used for any operation. (only available in x64 mode)
/// </summary>
public class R14D : IX64_32BitsGeneralPurposeRegister
{
    public string Name => nameof(R14D);
    public byte RegisterCode => 0x0E;
}

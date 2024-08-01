namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called R11W (extends the 8-bit R11B into 16-bit), doesn't have a dedicated role, can be used for any operation. (only available in x64 mode)
/// </summary>
public class R11W : IX64_16BitsGeneralPurposeRegister
{
    public string Name => nameof(R11W);
    public byte RegisterCode => 0x0B;
}

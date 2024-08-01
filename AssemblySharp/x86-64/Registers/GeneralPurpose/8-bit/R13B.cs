namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which represents the lower byte of the R13 register, doesn't have a dedicated role, can be used for any operation (only available in x64 mode)
/// </summary>
public sealed class R13B : IX64_8BitsGeneralPurposeRegister
{
    public string Name => nameof(R13B);
    public byte RegisterCode => 0x0D;
}

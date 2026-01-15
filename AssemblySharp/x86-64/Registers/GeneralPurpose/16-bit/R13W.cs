namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called R13W (extends the 8-bit R13B into 16-bit), doesn't have a dedicated role, can be used for any operation. (only available in x64 mode)
/// </summary>
public class R13W : IX64_16BitsGeneralPurposeRegister
{
	public string Name => nameof(R13W);
	public byte RegisterCode => 0x0D;
}

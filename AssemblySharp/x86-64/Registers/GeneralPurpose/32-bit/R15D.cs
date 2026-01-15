namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called R15D (extends the 16-bit R15W into 32-bit), doesn't have a dedicated role, can be used for any operation. (only available in x64 mode)
/// </summary>
public class R15D : IX64_32BitsGeneralPurposeRegister
{
	public string Name => nameof(R15D);
	public byte RegisterCode => 0x0F;
}

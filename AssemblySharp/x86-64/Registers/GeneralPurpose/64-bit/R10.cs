namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called R10 (extends the 32-bit R10D into 64-bit), doesn't have a dedicated role, can be used for any operation.
/// </summary>
public class R10 : IX64_64BitsGeneralPurposeRegister
{
	public string Name => nameof(R10);
	public byte RegisterCode => 0x0A;
}

namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called R9 (extends the 32-bit R9D into 64-bit), doesn't have a dedicated role, can be used for any operation.
/// </summary>
public class R9 : IX64_64BitsGeneralPurposeRegister
{
	public string Name => nameof(R9);
	public byte RegisterCode => 0x09;
}

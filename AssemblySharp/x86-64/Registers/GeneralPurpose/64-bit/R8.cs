namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called R8 (extends the 32-bit R8D into 64-bit), doesn't have a dedicated role, can be used for any operation.
/// </summary>
public class R8 : IX64_64BitsGeneralPurposeRegister
{
	public string Name => nameof(R8);
	public byte RegisterCode => 0x08;
}

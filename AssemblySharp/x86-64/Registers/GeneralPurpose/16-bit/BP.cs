namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Base Pointer", points to the beginning of the data on the stack (in the SS segment or "Stack Segment").
/// </summary>
public class BP : IX86_16BitsGeneralPurposeRegister, IX64_16BitsGeneralPurposeRegister
{
	public string Name => nameof(BP);
	public byte RegisterCode => 0x05;
}

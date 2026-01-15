namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Stack Pointer", points to the topmost item of the stack (in the SS segment or "Stack Segment").
/// </summary>
public class SP : IX86_16BitsGeneralPurposeRegister, IX64_16BitsGeneralPurposeRegister
{
	public string Name => nameof(SP);
	public byte RegisterCode => 0x04;
}

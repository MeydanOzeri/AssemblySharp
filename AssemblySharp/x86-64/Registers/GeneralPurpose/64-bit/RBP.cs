namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Base Pointer", (extends the 32-bit EBP register into 64-bit) points to the beginning of the data on the stack (in the SS segment or "Stack Segment").
/// </summary>
public class RBP : IX64_64BitsGeneralPurposeRegister
{
	public string Name => nameof(RBP);
	public byte RegisterCode => 0x05;
}

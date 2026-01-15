namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Stack Pointer", (extends the 32-bit ESP register into 64-bit) points to the topmost item of the stack (in the SS segment or "Stack Segment").
/// </summary>
public class RSP : IX64_64BitsGeneralPurposeRegister
{
	public string Name => nameof(RSP);
	public byte RegisterCode => 0x04;
}

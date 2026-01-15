using AssemblySharp.Addressing;

namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Extended Base Pointer", (extends the 16-bit BP register into 32-bit) points to the beginning of the data on the stack (in the SS segment or "Stack Segment").
/// </summary>
public class EBP : IX86_32BitsGeneralPurposeRegister, IX64_32BitsGeneralPurposeRegister
{
	public string Name => nameof(EBP);
	public byte RegisterCode => 0x05;
}

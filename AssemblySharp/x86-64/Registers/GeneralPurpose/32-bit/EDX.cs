namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Extended Data Register", (extends the 16-bit DX register into 32-bit) used to point to data in I/O operations.
/// </summary>
public class EDX : IX86_32BitsGeneralPurposeRegister, IX64_32BitsGeneralPurposeRegister
{
	public string Name => nameof(EDX);
	public byte RegisterCode => 0x02;
}

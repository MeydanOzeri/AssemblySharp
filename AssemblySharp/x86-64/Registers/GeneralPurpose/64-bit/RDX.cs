namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Data Register", (extends the 32-bit EDX register into 64-bit) used to point to data in I/O operations.
/// </summary>
public class RDX : IX64_64BitsGeneralPurposeRegister
{
	public string Name => nameof(RDX);
	public byte RegisterCode => 0x02;
}

namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called "Data Register", (extends the 8-bit DH and DL registers into 16-bit) used to point to data in I/O operations.
/// </summary>
public class DX : IX86_16BitsGeneralPurposeRegister, IX64_16BitsGeneralPurposeRegister
{
	public string Name => nameof(DX);
	public byte RegisterCode => 0x02;
}

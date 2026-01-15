namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which represents the lower byte of the DI register, (Destination Index) used as a pointer to data in the "Data Segment" (DS segment) usually used to point to the end of arrays/string/objects. (only available in x64 mode)
/// </summary>
public sealed class DIL : IX64_8BitsGeneralPurposeRegister
{
	public string Name => nameof(DIL);
	public byte RegisterCode => 0x07;
}

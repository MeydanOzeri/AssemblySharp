namespace AssemblySharp.Registers.Pointer;

/// <summary>
/// The extended instruction pointer (extends the 16-bit IP register), points to the location in memory of the next instruction to execute, cannot be manipulated directly, updates only by control flow instructions.
/// </summary>
public class EIP : IRegister
{
	public string Name => nameof(EIP);
	public byte RegisterCode => 0x05;
}

namespace AssemblySharp.Registers.Pointer;

/// <summary>
/// The 64-bit extended instruction pointer (extends the 32-bit EIP register), points to the location in memory of the next instruction to execute, cannot be manipulated directly, updates only by control flow instructions.
/// </summary>
public class RIP : IRegister
{
	public string Name => nameof(RIP);
	public byte RegisterCode => 0x05;
}

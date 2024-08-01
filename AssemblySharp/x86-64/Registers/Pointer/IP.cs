namespace AssemblySharp.Registers.Pointer;

/// <summary>
/// The instruction pointer, points to the location in memory of the next instruction to execute, cannot be manipulated directly, updates only by control flow instructions.
/// </summary>
public class IP : IRegister
{
    public string Name => nameof(IP);
    public byte RegisterCode => 0x05;
}

namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which represents the higher byte of the DX register, (Data Register) not available in x64 mode, used to point to data in I/O operations.
/// </summary>
public sealed class DH : IX86_8BitsGeneralPurposeRegister
{
    public string Name => nameof(DH);
    public byte RegisterCode => 0x06;
}

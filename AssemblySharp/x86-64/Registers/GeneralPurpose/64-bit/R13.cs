namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called R13 (extends the 32-bit R13D into 64-bit), doesn't have a dedicated role, can be used for any operation.
/// </summary>
public class R13 : IX64_64BitsGeneralPurposeRegister
{
    public string Name => nameof(R13);
    public byte RegisterCode => 0x0D;
}

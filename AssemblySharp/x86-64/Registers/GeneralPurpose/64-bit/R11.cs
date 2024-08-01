namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called R11 (extends the 32-bit R11D into 64-bit), doesn't have a dedicated role, can be used for any operation.
/// </summary>
public class R11 : IX64_64BitsGeneralPurposeRegister
{
    public string Name => nameof(R11);
    public byte RegisterCode => 0x0B;
}

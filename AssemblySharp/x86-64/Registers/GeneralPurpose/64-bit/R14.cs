namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called R14 (extends the 32-bit R14D into 64-bit), doesn't have a dedicated role, can be used for any operation.
/// </summary>
public class R14 : IX64_64BitsGeneralPurposeRegister
{
    public string Name => nameof(R14);
    public byte RegisterCode => 0x0E;
}

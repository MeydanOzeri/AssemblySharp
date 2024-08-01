namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called R12 (extends the 32-bit R12D into 64-bit), doesn't have a dedicated role, can be used for any operation.
/// </summary>
public class R12 : IX64_64BitsGeneralPurposeRegister
{
    public string Name => nameof(R12);
    public byte RegisterCode => 0x0C;
}

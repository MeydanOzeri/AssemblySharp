namespace AssemblySharp.Registers.GeneralPurpose;

/// <summary>
/// A general purpose register which is called R15 (extends the 32-bit R15D into 64-bit), doesn't have a dedicated role, can be used for any operation.
/// </summary>
public class R15 : IX64_64BitsGeneralPurposeRegister
{
    public string Name => nameof(R15);
    public byte RegisterCode => 0x0F;
}

namespace AssemblySharp.Addressing;

/// <summary>
/// Represents the Mod field in the ModR/M byte, indicating addressing modes.
/// </summary>
[SuppressMessage("Design", "CA1069:Enums values should not be duplicated", Justification = "Stay true to how assembly defines these prefixes")]
internal enum ModType
{
    /// <summary>
    /// Memory addressing mode with no displacement (mod = 00).
    /// Example: [BX + SI] - Data is at the memory address computed by adding the contents of BX and SI registers.
    /// </summary>
    MEMORY_ADDRESSING_MODE = 0x00,

    /// <summary>
    /// Register indirect addressing mode (mod = 00).
    /// Example: [EBP] - Data is at the memory address contained directly in the EBP register.
    /// </summary>
    REGISTER_INDIRECT_ADDRESSING_MODE = 0x00,

    /// <summary>
    /// Memory addressing mode with one-byte signed displacement (mod = 01).
    /// Example: [BX + disp8] - Data is at the memory address computed by BX register plus an 8-bit displacement.
    /// </summary>
    ONE_BYTE_SIGNED_DISPLACEMENT = 0x01,

    /// <summary>
    /// Memory addressing mode with two-byte signed displacement (mod = 10, used in 16-bit mode).
    /// Example: [BP + disp16] - Data is at the memory address computed by BP register plus a 16-bit displacement in 16-bit mode.
    /// </summary>
    TWO_BYTE_SIGNED_DISPLACEMENT = 0x02,

    /// <summary>
    /// Memory addressing mode with four-byte signed displacement (mod = 10).
    /// Example: [EBX + disp32] - Data is at the memory address computed by EBX register plus a 32-bit displacement.
    /// </summary>
    FOUR_BYTE_SIGNED_DISPLACEMENT = 0x02,

    /// <summary>
    /// Memory addressing mode with eight-byte signed displacement (mod = 10, applicable in 64-bit mode).
    /// Example: [RAX + disp64] - Data is at the memory address computed by RAX register plus a 64-bit displacement in 64-bit mode.
    /// </summary>
    EIGHT_BYTE_SIGNED_DISPLACEMENT = 0x02,

    /// <summary>
    /// Register direct addressing mode (mod = 11).
    /// Example: ECX - Data is in the ECX register itself.
    /// </summary>
    REGISTER_DIRECT_ADDRESSING_MODE = 0x03
}

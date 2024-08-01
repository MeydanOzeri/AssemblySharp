using AssemblySharp.Registers;

namespace AssemblySharp.Addressing;

/// <summary>
/// Represents the ModRM byte, a component of x86 and x64 instruction encoding that specifies how operands (registers and memory) are addressed.
/// </summary>
internal readonly record struct ModRM
{
    /// <summary>
    /// The Mod (Mode) field specifies the addressing mode.
    /// It determines how the R/M field should be interpreted and whether a displacement follows the ModRM byte.
    /// </summary>
    public ModType Mod { get; init; }

    /// <summary>
    /// The Reg (Register) field often specifies the register that is used as an operand in the instruction.
    /// It can also extend the primary opcode of the instruction in certain contexts.
    /// </summary>
    public byte Reg { get; init; }

    /// <summary>
    /// The R/M (Register/Memory) field specifies the other operand of the instruction,
    /// which can be either a register or a memory address.
    /// The interpretation of this field depends on the Mod field.
    /// </summary>
    public byte Rm { get; init; }

    /// <summary>
    /// Encodes the ModRM byte based on the Mod, Reg, and R/M fields.
    /// </summary>
    /// <returns>The encoded ModRM byte.</returns>
    public byte Encode() => (byte)(((byte)Mod << 6) | (Reg << 3) | Rm);

    /// <summary>
    /// Determines the ModType for a given displacement.
    /// </summary>
    /// <param name="displacement">The displacement to get the ModType for.</param>
    /// <returns>The corresponding ModType based on the displacement size.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the displacement type does not match a valid ModType.</exception>
    public static ModType GetModType(byte[] displacement) => true switch
    {
        true when displacement.Length == 0 => ModType.REGISTER_INDIRECT_ADDRESSING_MODE,
        true when displacement.Length == 1 && displacement[0] <= sbyte.MaxValue => ModType.ONE_BYTE_SIGNED_DISPLACEMENT,
        true when displacement.Length == 1 && displacement[0] > sbyte.MaxValue => ModType.TWO_BYTE_SIGNED_DISPLACEMENT,
        true when displacement.Length == 2 => ModType.TWO_BYTE_SIGNED_DISPLACEMENT,
        true when displacement.Length == 4 => ModType.FOUR_BYTE_SIGNED_DISPLACEMENT,
        true when displacement.Length == 8 => ModType.EIGHT_BYTE_SIGNED_DISPLACEMENT,
        _ => throw new InvalidOperationException($"There is no Mod for a {displacement.Length * 8}-bit displacement")
    };
}

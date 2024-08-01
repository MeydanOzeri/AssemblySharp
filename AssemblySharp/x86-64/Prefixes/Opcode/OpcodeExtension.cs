namespace AssemblySharp.Prefixes.Opcode;

/// <summary>
/// Prefixes used for extending or modifying the base opcode, particularly in modern x86 and x64 instruction sets.
/// </summary>
internal enum OpcodeExtension
{
    /// <summary>
    /// Used as a lead-in for two-byte opcodes, expanding the opcode space.
    /// </summary>
    TWO_BYTE_OPCODE = 0x0F,

    /// <summary>
    /// Prefix used in SIMD operations to modify or extend the operation of an instruction.
    /// </summary>
    SIMD_PREFIX = 0x66,

    /// <summary>
    /// Branch hint prefix, used to provide hints for branch prediction in some processors.
    /// </summary>
    BRANCH_HINT = 0xF2,

    /// <summary>
    /// Repeat prefix for string and I/O instructions, used to repeat the operation for each element of a string or I/O operation.
    /// </summary>
    REPEAT_PREFIX = 0xF3
}

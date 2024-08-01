namespace AssemblySharp.Prefixes.Legacy;

/// <summary>
/// Prefixes for atomic operations and string operations repetition.
/// </summary>
internal enum LockAndRepeat
{
    /// <summary>
    /// LOCK prefix for atomic memory operations, ensuring exclusive memory access in multi-processor environments.
    /// </summary>
    LOCK = 0xF0,

    /// <summary>
    /// REPNE/REPNZ: Repeat string operation while ZF (zero flag) is clear. Used with string comparison/scanning instructions.
    /// </summary>
    REPNE = 0xF2,

    /// <summary>
    /// REP/REPE/REPZ: Repeat string operation while ZF (zero flag) is set. Used with string and I/O instructions.
    /// </summary>
    REP = 0xF3
}

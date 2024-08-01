namespace AssemblySharp.Prefixes.Legacy;

/// <summary>
/// Prefix to override the default operand size (e.g., from 32-bit to 16-bit).
/// </summary>
internal enum OperandSizeOverride
{
    /// <summary>
    /// Operand-size override prefix, changes operand size (e.g., in 32-bit mode, switches from 32-bit to 16-bit operands).
    /// </summary>
    OPERAND_SIZE_OVERRIDE = 0x66
}

namespace AssemblySharp.Prefixes.Legacy;

/// <summary>
/// Prefix to override the default address size for memory operations.
/// </summary>
internal enum AddressSizeOverride
{
	/// <summary>
	/// Address-size override prefix, modifies the size of memory addresses used in the instruction.
	/// </summary>
	ADDRESS_SIZE_OVERRIDE = 0x67,
}

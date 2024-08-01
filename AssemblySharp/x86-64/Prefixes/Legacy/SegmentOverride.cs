namespace AssemblySharp.Prefixes.Legacy;

/// <summary>
/// Prefixes for overriding default segment registers in memory addressing.
/// </summary>
internal enum SegmentOverride
{
    /// <summary>
    /// Overrides the default segment with ES (Extra Segment).
    /// </summary>
    ES_SEGMENT_OVERRIDE = 0x26,

    /// <summary>
    /// Overrides the default segment with CS (Code Segment).
    /// </summary>
    CS_SEGMENT_OVERRIDE = 0x2E,

    /// <summary>
    /// Overrides the default segment with SS (Stack Segment).
    /// </summary>
    SS_SEGMENT_OVERRIDE = 0x36,

    /// <summary>
    /// Overrides the default segment with DS (Data Segment).
    /// </summary>
    DS_SEGMENT_OVERRIDE = 0x3E,

    /// <summary>
    /// Overrides the default segment with FS. Used for local thread storage.
    /// </summary>
    FS_SEGMENT_OVERRIDE = 0x64,

    /// <summary>
    /// Overrides the default segment with GS. Commonly used for operating system-specific data structures.
    /// </summary>
    GS_SEGMENT_OVERRIDE = 0x65
}

namespace AssemblySharp.Addressing;

public record class ImmediateAddressing<TDisplacementType> : IMemoryAddressing where TDisplacementType : ISignedNumber<TDisplacementType>
{
    public TDisplacementType Displacement { get; init; } = TDisplacementType.Zero;
}

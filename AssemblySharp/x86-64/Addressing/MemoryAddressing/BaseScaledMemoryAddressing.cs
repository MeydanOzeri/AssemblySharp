using AssemblySharp.Registers;

namespace AssemblySharp.Addressing;

public record class BaseScaledMemoryAddressing<TBase, TIndex, TDisplacementType> : IMemoryAddressing
	where TBase : IRegister
	where TIndex : IRegister
	where TDisplacementType : ISignedNumber<TDisplacementType>
{
	public required TBase Base { get; init; }
	public required TIndex Index { get; init; }
	public byte ScaleFactor
	{
		get;
		init => field = value is 1 or 2 or 4 or 8 ? value : throw new InvalidOperationException("The scale factor must be either 1 or 2 or 4 or 8.");
	} = 1;
	public TDisplacementType Displacement { get; init; } = TDisplacementType.Zero;

	public static BaseScaledMemoryAddressing<TBase, TIndex, TDisplacementType> operator -(
		BaseScaledMemoryAddressing<TBase, TIndex, TDisplacementType> baseScaledMemoryAddressing,
		TDisplacementType displacement
	) => baseScaledMemoryAddressing with { Displacement = baseScaledMemoryAddressing.Displacement - displacement };

	public static BaseScaledMemoryAddressing<TBase, TIndex, TDisplacementType> operator -(
		TDisplacementType displacement,
		BaseScaledMemoryAddressing<TBase, TIndex, TDisplacementType> baseScaledMemoryAddressing
	) => baseScaledMemoryAddressing - displacement;

	public static BaseScaledMemoryAddressing<TBase, TIndex, TDisplacementType> operator +(
		BaseScaledMemoryAddressing<TBase, TIndex, TDisplacementType> baseScaledMemoryAddressing,
		TDisplacementType displacement
	) => baseScaledMemoryAddressing with { Displacement = baseScaledMemoryAddressing.Displacement + displacement };

	public static BaseScaledMemoryAddressing<TBase, TIndex, TDisplacementType> operator +(
		TDisplacementType displacement,
		BaseScaledMemoryAddressing<TBase, TIndex, TDisplacementType> baseScaledMemoryAddressing
	) => baseScaledMemoryAddressing + displacement;
}

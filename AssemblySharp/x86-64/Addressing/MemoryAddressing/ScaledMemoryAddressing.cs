using AssemblySharp.Registers;

namespace AssemblySharp.Addressing;

public record class ScaledMemoryAddressing<TIndex, TAllowedBase, TDisplacementType> : IMemoryAddressing
	where TIndex : IRegister
	where TAllowedBase : IRegister
	where TDisplacementType : ISignedNumber<TDisplacementType>
{
	public required TIndex Index { get; init; }
	public byte ScaleFactor
	{
		get;
		init => field = value is 1 or 2 or 4 or 8 ? value : throw new InvalidOperationException("The scale factor must be one of 1,2,4,8 scale factors.");
	} = 1;
	public TDisplacementType Displacement { get; init; } = TDisplacementType.Zero;

	public static ScaledMemoryAddressing<TIndex, TAllowedBase, TDisplacementType> operator -(
		ScaledMemoryAddressing<TIndex, TAllowedBase, TDisplacementType> scaledMemoryAddressing,
		TDisplacementType displacement
	) => scaledMemoryAddressing with { Displacement = scaledMemoryAddressing.Displacement - displacement };

	public static ScaledMemoryAddressing<TIndex, TAllowedBase, TDisplacementType> operator -(
		TDisplacementType displacement,
		ScaledMemoryAddressing<TIndex, TAllowedBase, TDisplacementType> scaledMemoryAddressing
	) => scaledMemoryAddressing - displacement;

	public static ScaledMemoryAddressing<TIndex, TAllowedBase, TDisplacementType> operator +(
		ScaledMemoryAddressing<TIndex, TAllowedBase, TDisplacementType> scaledMemoryAddressing,
		TDisplacementType displacement
	) => scaledMemoryAddressing with { Displacement = scaledMemoryAddressing.Displacement + displacement };

	public static ScaledMemoryAddressing<TIndex, TAllowedBase, TDisplacementType> operator +(
		TDisplacementType displacement,
		ScaledMemoryAddressing<TIndex, TAllowedBase, TDisplacementType> scaledMemoryAddressing
	) => scaledMemoryAddressing + displacement;

	public static BaseScaledMemoryAddressing<TAllowedBase, TIndex, TDisplacementType> operator +(
		ScaledMemoryAddressing<TIndex, TAllowedBase, TDisplacementType> scaledMemoryAddressing,
		TAllowedBase baseRegister
	) =>
		new()
		{
			Base = baseRegister,
			Index = scaledMemoryAddressing.Index,
			ScaleFactor = scaledMemoryAddressing.ScaleFactor,
			Displacement = scaledMemoryAddressing.Displacement,
		};

	public static BaseScaledMemoryAddressing<TAllowedBase, TIndex, TDisplacementType> operator +(
		TAllowedBase baseRegister,
		ScaledMemoryAddressing<TIndex, TAllowedBase, TDisplacementType> scaledMemoryAddressing
	) => scaledMemoryAddressing + baseRegister;

	public static BaseScaledMemoryAddressing<TAllowedBase, TIndex, TDisplacementType> operator +(
		ScaledMemoryAddressing<TIndex, TAllowedBase, TDisplacementType> scaledMemoryAddressing,
		BaseMemoryAddressing<TAllowedBase, TIndex, TDisplacementType> baseMemoryAddressing
	) =>
		new()
		{
			Base = baseMemoryAddressing.Base,
			Index = scaledMemoryAddressing.Index,
			ScaleFactor = scaledMemoryAddressing.ScaleFactor,
			Displacement = baseMemoryAddressing.Displacement + scaledMemoryAddressing.Displacement,
		};
}

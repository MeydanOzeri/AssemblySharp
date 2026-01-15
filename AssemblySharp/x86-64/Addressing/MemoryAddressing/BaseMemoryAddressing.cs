using AssemblySharp.Registers;

namespace AssemblySharp.Addressing;

public record class BaseMemoryAddressing<TBase, TAllowedIndex, TDisplacementType> : IMemoryAddressing
	where TBase : IRegister
	where TAllowedIndex : IRegister
	where TDisplacementType : ISignedNumber<TDisplacementType>
{
	public required TBase Base { get; init; }
	public TDisplacementType Displacement { get; init; } = TDisplacementType.Zero;

	public static BaseMemoryAddressing<TBase, TAllowedIndex, TDisplacementType> operator -(
		BaseMemoryAddressing<TBase, TAllowedIndex, TDisplacementType> baseMemoryAddressing,
		TDisplacementType displacement
	) => baseMemoryAddressing with { Displacement = baseMemoryAddressing.Displacement - displacement };

	public static BaseMemoryAddressing<TBase, TAllowedIndex, TDisplacementType> operator -(
		TDisplacementType displacement,
		BaseMemoryAddressing<TBase, TAllowedIndex, TDisplacementType> baseMemoryAddressing
	) => baseMemoryAddressing - displacement;

	public static BaseMemoryAddressing<TBase, TAllowedIndex, TDisplacementType> operator +(
		BaseMemoryAddressing<TBase, TAllowedIndex, TDisplacementType> baseMemoryAddressing,
		TDisplacementType displacement
	) => baseMemoryAddressing with { Displacement = baseMemoryAddressing.Displacement + displacement };

	public static BaseMemoryAddressing<TBase, TAllowedIndex, TDisplacementType> operator +(
		TDisplacementType displacement,
		BaseMemoryAddressing<TBase, TAllowedIndex, TDisplacementType> baseMemoryAddressing
	) => baseMemoryAddressing + displacement;

	public static BaseScaledMemoryAddressing<TBase, TAllowedIndex, TDisplacementType> operator +(
		BaseMemoryAddressing<TBase, TAllowedIndex, TDisplacementType> baseMemoryAddressing,
		TAllowedIndex indexRegister
	) =>
		new()
		{
			Base = baseMemoryAddressing.Base,
			Index = indexRegister,
			Displacement = baseMemoryAddressing.Displacement,
		};

	public static BaseScaledMemoryAddressing<TBase, TAllowedIndex, TDisplacementType> operator +(
		TAllowedIndex indexRegister,
		BaseMemoryAddressing<TBase, TAllowedIndex, TDisplacementType> baseMemoryAddressing
	) => baseMemoryAddressing + indexRegister;

	public static BaseScaledMemoryAddressing<TBase, TAllowedIndex, TDisplacementType> operator +(
		BaseMemoryAddressing<TBase, TAllowedIndex, TDisplacementType> baseMemoryAddressing1,
		BaseMemoryAddressing<TAllowedIndex, TBase, TDisplacementType> baseMemoryAddressing2
	) =>
		new()
		{
			Base = baseMemoryAddressing1.Base,
			Index = baseMemoryAddressing2.Base,
			Displacement = baseMemoryAddressing1.Displacement + baseMemoryAddressing2.Displacement,
		};

	public static BaseScaledMemoryAddressing<TBase, TAllowedIndex, TDisplacementType> operator +(
		BaseMemoryAddressing<TBase, TAllowedIndex, TDisplacementType> baseMemoryAddressing,
		ScaledMemoryAddressing<TAllowedIndex, TBase, TDisplacementType> scaledMemoryAddressing
	) =>
		new()
		{
			Base = baseMemoryAddressing.Base,
			Index = scaledMemoryAddressing.Index,
			ScaleFactor = scaledMemoryAddressing.ScaleFactor,
			Displacement = baseMemoryAddressing.Displacement + scaledMemoryAddressing.Displacement,
		};
}

using AssemblySharp.Addressing;

namespace AssemblySharp.Registers.GeneralPurpose;

public class X64_32BitMemoryAddressableRegister<T> : IX64_32BitsGeneralPurposeRegister
	where T : IX64_32BitsGeneralPurposeRegister
{
	private X64_32BitMemoryAddressableRegister(T register)
	{
		Name = register.Name;
		RegisterCode = register.RegisterCode;
	}

	public string Name { get; }
	public byte RegisterCode { get; }

	private static X64_32BitMemoryAddressableRegisters ToUnion(X64_32BitMemoryAddressableRegister<T> x64_32BitMemoryAddressableRegister) =>
		x64_32BitMemoryAddressableRegister switch
		{
			X64_32BitMemoryAddressableRegister<EAX> register => register,
			X64_32BitMemoryAddressableRegister<EBP> register => register,
			X64_32BitMemoryAddressableRegister<EBX> register => register,
			X64_32BitMemoryAddressableRegister<ECX> register => register,
			X64_32BitMemoryAddressableRegister<EDI> register => register,
			X64_32BitMemoryAddressableRegister<EDX> register => register,
			X64_32BitMemoryAddressableRegister<ESI> register => register,
			X64_32BitMemoryAddressableRegister<ESP> register => register,
			X64_32BitMemoryAddressableRegister<R8D> register => register,
			X64_32BitMemoryAddressableRegister<R9D> register => register,
			X64_32BitMemoryAddressableRegister<R10D> register => register,
			X64_32BitMemoryAddressableRegister<R11D> register => register,
			X64_32BitMemoryAddressableRegister<R12D> register => register,
			X64_32BitMemoryAddressableRegister<R13D> register => register,
			X64_32BitMemoryAddressableRegister<R14D> register => register,
			X64_32BitMemoryAddressableRegister<R15D> register => register,
			_ => throw new InvalidOperationException(),
		};

	public static implicit operator X64_32BitMemoryAddressableRegister<T>(T register) => new(register);

	public static BaseMemoryAddressing<X64_32BitMemoryAddressableRegisters, X64_32BitMemoryAddressableRegisters, int> operator -(
		X64_32BitMemoryAddressableRegister<T> register,
		int displacement
	) => new() { Base = ToUnion(register), Displacement = -displacement };

	public static BaseMemoryAddressing<X64_32BitMemoryAddressableRegisters, X64_32BitMemoryAddressableRegisters, int> operator -(
		int displacement,
		X64_32BitMemoryAddressableRegister<T> register
	) => register - displacement;

	public static BaseMemoryAddressing<X64_32BitMemoryAddressableRegisters, X64_32BitMemoryAddressableRegisters, int> operator +(
		X64_32BitMemoryAddressableRegister<T> register,
		int displacement
	) => new() { Base = ToUnion(register), Displacement = displacement };

	public static BaseMemoryAddressing<X64_32BitMemoryAddressableRegisters, X64_32BitMemoryAddressableRegisters, int> operator +(
		int displacement,
		X64_32BitMemoryAddressableRegister<T> register
	) => register + displacement;

	public static ScaledMemoryAddressing<X64_32BitMemoryAddressableRegisters, X64_32BitMemoryAddressableRegisters, int> operator *(
		X64_32BitMemoryAddressableRegister<T> indexRegister,
		byte scale
	) => new() { Index = ToUnion(indexRegister), ScaleFactor = scale };

	public static ScaledMemoryAddressing<X64_32BitMemoryAddressableRegisters, X64_32BitMemoryAddressableRegisters, int> operator *(
		byte scale,
		X64_32BitMemoryAddressableRegister<T> indexRegister
	) => indexRegister * scale;

	public static BaseScaledMemoryAddressing<X64_32BitMemoryAddressableRegisters, X64_32BitMemoryAddressableRegisters, int> operator +(
		X64_32BitMemoryAddressableRegister<T> baseRegister,
		X64_32BitMemoryAddressableRegisters indexRegister
	) => new() { Base = ToUnion(baseRegister), Index = indexRegister };
}

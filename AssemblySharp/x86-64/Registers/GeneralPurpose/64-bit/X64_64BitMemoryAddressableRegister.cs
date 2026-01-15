using AssemblySharp.Addressing;

namespace AssemblySharp.Registers.GeneralPurpose;

public class X64_64BitMemoryAddressableRegister<T> : IX64_64BitsGeneralPurposeRegister
	where T : IX64_64BitsGeneralPurposeRegister
{
	private X64_64BitMemoryAddressableRegister(T register)
	{
		Name = register.Name;
		RegisterCode = register.RegisterCode;
	}

	public string Name { get; }
	public byte RegisterCode { get; }

	public static implicit operator X64_64BitMemoryAddressableRegister<T>(T register) => new(register);

	private static X64_64BitMemoryAddressableRegisters ToUnion(X64_64BitMemoryAddressableRegister<T> x64_64BitMemoryAddressableRegister) =>
		x64_64BitMemoryAddressableRegister switch
		{
			X64_64BitMemoryAddressableRegister<RAX> register => register,
			X64_64BitMemoryAddressableRegister<RBP> register => register,
			X64_64BitMemoryAddressableRegister<RBX> register => register,
			X64_64BitMemoryAddressableRegister<RCX> register => register,
			X64_64BitMemoryAddressableRegister<RDI> register => register,
			X64_64BitMemoryAddressableRegister<RDX> register => register,
			X64_64BitMemoryAddressableRegister<RSI> register => register,
			X64_64BitMemoryAddressableRegister<RSP> register => register,
			X64_64BitMemoryAddressableRegister<R8> register => register,
			X64_64BitMemoryAddressableRegister<R9> register => register,
			X64_64BitMemoryAddressableRegister<R10> register => register,
			X64_64BitMemoryAddressableRegister<R11> register => register,
			X64_64BitMemoryAddressableRegister<R12> register => register,
			X64_64BitMemoryAddressableRegister<R13> register => register,
			X64_64BitMemoryAddressableRegister<R14> register => register,
			X64_64BitMemoryAddressableRegister<R15> register => register,
			_ => throw new InvalidOperationException(),
		};

	public static BaseMemoryAddressing<X64_64BitMemoryAddressableRegisters, X64_64BitMemoryAddressableRegisters, int> operator -(
		X64_64BitMemoryAddressableRegister<T> register,
		int displacement
	) => new() { Base = ToUnion(register), Displacement = -displacement };

	public static BaseMemoryAddressing<X64_64BitMemoryAddressableRegisters, X64_64BitMemoryAddressableRegisters, int> operator -(
		int displacement,
		X64_64BitMemoryAddressableRegister<T> register
	) => register - displacement;

	public static BaseMemoryAddressing<X64_64BitMemoryAddressableRegisters, X64_64BitMemoryAddressableRegisters, int> operator +(
		X64_64BitMemoryAddressableRegister<T> register,
		int displacement
	) => new() { Base = ToUnion(register), Displacement = displacement };

	public static BaseMemoryAddressing<X64_64BitMemoryAddressableRegisters, X64_64BitMemoryAddressableRegisters, int> operator +(
		int displacement,
		X64_64BitMemoryAddressableRegister<T> register
	) => register + displacement;

	public static ScaledMemoryAddressing<X64_64BitMemoryAddressableRegisters, X64_64BitMemoryAddressableRegisters, int> operator *(
		X64_64BitMemoryAddressableRegister<T> indexRegister,
		byte scale
	) => new() { Index = ToUnion(indexRegister), ScaleFactor = scale };

	public static ScaledMemoryAddressing<X64_64BitMemoryAddressableRegisters, X64_64BitMemoryAddressableRegisters, int> operator *(
		byte scale,
		X64_64BitMemoryAddressableRegister<T> indexRegister
	) => indexRegister * scale;

	public static BaseScaledMemoryAddressing<X64_64BitMemoryAddressableRegisters, X64_64BitMemoryAddressableRegisters, int> operator +(
		X64_64BitMemoryAddressableRegister<T> baseRegister,
		X64_64BitMemoryAddressableRegisters indexRegister
	) => new() { Base = ToUnion(baseRegister), Index = indexRegister };
}

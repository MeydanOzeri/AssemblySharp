using AssemblySharp.Addressing;

namespace AssemblySharp.Registers.GeneralPurpose;

public class X86_32BitMemoryAddressableRegister<T> : IX86_32BitsGeneralPurposeRegister
	where T : IX86_32BitsGeneralPurposeRegister
{
	protected X86_32BitMemoryAddressableRegister(T register)
	{
		Name = register.Name;
		RegisterCode = register.RegisterCode;
	}

	public string Name { get; }
	public byte RegisterCode { get; }

	private static X86_32BitMemoryAddressableRegisters ToUnion(X86_32BitMemoryAddressableRegister<T> x86_32BitMemoryAddressableRegister) =>
		x86_32BitMemoryAddressableRegister switch
		{
			X86_32BitScalableRegister<EAX> register => register,
			X86_32BitScalableRegister<EBP> register => register,
			X86_32BitScalableRegister<EBX> register => register,
			X86_32BitScalableRegister<ECX> register => register,
			X86_32BitScalableRegister<EDI> register => register,
			X86_32BitScalableRegister<EDX> register => register,
			X86_32BitScalableRegister<ESI> register => register,
			X86_32BitMemoryAddressableRegister<ESP> register => register,
			_ => throw new InvalidOperationException(),
		};

	public static implicit operator X86_32BitMemoryAddressableRegister<T>(T register) => new(register);

	public static BaseMemoryAddressing<X86_32BitMemoryAddressableRegisters, X86_32BitMemoryAddressableRegisters, int> operator -(
		X86_32BitMemoryAddressableRegister<T> register,
		int displacement
	) => new() { Base = ToUnion(register), Displacement = -displacement };

	public static BaseMemoryAddressing<X86_32BitMemoryAddressableRegisters, X86_32BitMemoryAddressableRegisters, int> operator -(
		int displacement,
		X86_32BitMemoryAddressableRegister<T> register
	) => register - displacement;

	public static BaseMemoryAddressing<X86_32BitMemoryAddressableRegisters, X86_32BitMemoryAddressableRegisters, int> operator +(
		X86_32BitMemoryAddressableRegister<T> register,
		int displacement
	) => new() { Base = ToUnion(register), Displacement = displacement };

	public static BaseMemoryAddressing<X86_32BitMemoryAddressableRegisters, X86_32BitMemoryAddressableRegisters, int> operator +(
		int displacement,
		X86_32BitMemoryAddressableRegister<T> register
	) => register + displacement;

	public static BaseScaledMemoryAddressing<X86_32BitMemoryAddressableRegisters, X86_32BitMemoryAddressableRegisters, int> operator +(
		X86_32BitMemoryAddressableRegister<T> baseRegister,
		X86_32BitMemoryAddressableRegisters indexRegister
	) => new() { Base = ToUnion(baseRegister), Index = indexRegister };
}

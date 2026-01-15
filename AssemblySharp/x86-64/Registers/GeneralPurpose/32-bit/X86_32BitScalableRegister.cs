using AssemblySharp.Addressing;

namespace AssemblySharp.Registers.GeneralPurpose;

public class X86_32BitScalableRegister<T> : X86_32BitMemoryAddressableRegister<T>
	where T : IX86_32BitsGeneralPurposeRegister
{
	private X86_32BitScalableRegister(T register)
		: base(register) { }

	public static implicit operator X86_32BitScalableRegister<T>(T register) => new(register);

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

	public static ScaledMemoryAddressing<X86_32BitMemoryAddressableRegisters, X86_32BitMemoryAddressableRegisters, int> operator *(
		X86_32BitScalableRegister<T> indexRegister,
		byte scale
	) => new() { Index = ToUnion(indexRegister), ScaleFactor = scale };

	public static ScaledMemoryAddressing<X86_32BitMemoryAddressableRegisters, X86_32BitMemoryAddressableRegisters, int> operator *(
		byte scale,
		X86_32BitScalableRegister<T> indexRegister
	) => indexRegister * scale;
}

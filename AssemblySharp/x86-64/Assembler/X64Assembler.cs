using AssemblySharp.Addressing;
using AssemblySharp.Registers.GeneralPurpose;

namespace AssemblySharp.X64;

public sealed class X64Assembler
{
	public X64Assembler Mov(IX64_8BitsGeneralPurposeRegister destination, IX64_8BitsGeneralPurposeRegister source) => this;

	public X64Assembler Mov(IX64_16BitsGeneralPurposeRegister destination, IX64_16BitsGeneralPurposeRegister source) => this;

	public X64Assembler Mov(IX64_32BitsGeneralPurposeRegister destination, IX64_32BitsGeneralPurposeRegister source) => this;

	public X64Assembler Mov(IX64_64BitsGeneralPurposeRegister destination, IX64_64BitsGeneralPurposeRegister source) => this;

	public X64Assembler Mov(X64GeneralPurposeRegisters destination, int[] source) => this;

	public X64Assembler Mov(int[] destination, X64GeneralPurposeRegisters source) => this;

	public X64Assembler Mov(X64_64BitMemoryAddressableRegister<RAX> destination, long[] source) => this;

	public X64Assembler Mov(long[] destination, X64_64BitMemoryAddressableRegister<RAX> source) => this;

	public X64Assembler Mov(X64GeneralPurposeRegisters destination, X64_32BitMemoryAddressableRegisters[] source) => this;

	public X64Assembler Mov(X64GeneralPurposeRegisters destination, X64_64BitMemoryAddressableRegisters[] source) => this;

	public X64Assembler Mov(X64_32BitMemoryAddressableRegisters[] destination, X64GeneralPurposeRegisters source) => this;

	public X64Assembler Mov(X64_64BitMemoryAddressableRegisters[] destination, X64GeneralPurposeRegisters source) => this;

	public X64Assembler Mov(X64GeneralPurposeRegisters destination, ImmediateAddressing<int>[] source) => this;

	public X64Assembler Mov(ImmediateAddressing<int>[] destination, X64GeneralPurposeRegisters source) => this;

	public byte[] Assemble() => throw new NotImplementedException();
}

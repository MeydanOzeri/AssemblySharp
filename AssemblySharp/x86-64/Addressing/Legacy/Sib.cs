namespace AssemblySharp.Addressing;

internal readonly record struct Sib
{
	public ScaleFactor Scale { get; init; }
	public byte Index { get; init; }
	public byte Base { get; init; }

	public byte Encode() => (byte)(((byte)Scale << 6) | (Index << 3) | Base);

	public static ScaleFactor GetScaleFactor(byte scale) =>
		scale switch
		{
			1 => ScaleFactor.One,
			2 => ScaleFactor.Two,
			4 => ScaleFactor.Four,
			8 => ScaleFactor.Eight,
			_ => throw new InvalidOperationException($"There is no supported scale factor {scale}"),
		};
}

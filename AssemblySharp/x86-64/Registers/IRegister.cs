namespace AssemblySharp.Registers;

public interface IRegister
{
    public string Name { get; }
    public byte RegisterCode { get; }
}

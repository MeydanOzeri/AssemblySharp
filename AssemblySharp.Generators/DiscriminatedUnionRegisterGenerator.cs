
using System.Linq;
using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace AssemblySharp.Generators;

[Generator]
public class DiscriminatedUnionRegisterGenerator : IIncrementalGenerator
{
    private static bool IsRegisterTypeWithGenericUsed(SyntaxNode syntaxNode)
    {
        return syntaxNode is GenericNameSyntax genericNameSyntax
            && genericNameSyntax.Identifier.Text.Equals("Register")
            && genericNameSyntax.TypeArgumentList.Arguments.Count > 0;
    }

    private static int CountRegisterGenericTypes(GenericNameSyntax registerTypeWithGeneric) => registerTypeWithGeneric.TypeArgumentList.Arguments.Count;

    private static string GenerateRegisterGenericClass(int registersCount)
    {
        var registers = Enumerable.Range(1, registersCount).Select(registerCount => $"R{registerCount}");
        var registerNames = string.Join(", ", registers);
        var registerConstraints = string.Join(" ", registers.Select(register => $"where {register} : IRegister"));
        var registerImplicitOperators = string.Join("\n", registers.Select(register => $"\tpublic static implicit operator Register<{registerNames}>({register} register) => new(register);"));

        return $@"
public class Register<{registerNames}> : IRegister {registerConstraints}
{{
    private Register(IRegister register)
    {{
        Name = register.Name;
        RegisterCode = register.RegisterCode;
    }}
            
    public string Name {{ get; }}
    public byte RegisterCode {{ get; }}

{registerImplicitOperators}
}}";
    }

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var genericRegisterClassesInUseProvider = context.SyntaxProvider.CreateSyntaxProvider
        (
            predicate: static (syntaxNode, cancellationToken) => IsRegisterTypeWithGenericUsed(syntaxNode),
            transform: static (syntaxNode, cancellationToken) => CountRegisterGenericTypes(syntaxNode.Node as GenericNameSyntax)
        ).Collect();

        context.RegisterSourceOutput(genericRegisterClassesInUseProvider, (sourceProductionContext, genericRegisterClassesInUse) =>
        {
            var genericRegisterClasses = new StringBuilder("namespace AssemblySharp.Registers;").AppendLine();
            foreach (var genericRegisterClassInUse in genericRegisterClassesInUse.Distinct())
            {
                _ = genericRegisterClasses.AppendLine(GenerateRegisterGenericClass(genericRegisterClassInUse));
            }
            sourceProductionContext.AddSource("DiscriminatedUnionRegisterGenerator.g", SourceText.From(genericRegisterClasses.ToString(), Encoding.UTF8));
        });
    }
}

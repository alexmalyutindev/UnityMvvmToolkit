using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace UnityMvvmToolkit.Gen;

[Generator]
public class BindingsGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForSyntaxNotifications(() => new BindableAttributeReceiver());
    }

    public void Execute(GeneratorExecutionContext context)
    {
        if (context.SyntaxReceiver is BindableAttributeReceiver receiver)
        {
            foreach (var classInfo in receiver.ClassesWithAttributes)
            {
                Console.WriteLine(">> " + classInfo.Name);
                var source = new StringBuilder();

                if (!String.IsNullOrEmpty(classInfo.Namespace))
                {
                    source.Append("namespace ").Append(classInfo.Namespace).AppendLine("{");
                }

                source.AppendLine(@"using UnityMvvmToolkit.Core;
using UnityMvvmToolkit.Core.Enums;
using UnityMvvmToolkit.Core.Interfaces;"
                );

                source.AppendLine("public partial class " + classInfo.Name + " : IObjectProvider");
                source.AppendLine("{");


                // source.AppendLine(@"public TCommand GetCommand<TCommand>(IBindingContext context, string propertyName) where TCommand : IBaseCommand
                // {
                //     throw new NotImplementedException();
                // }");
                
                source.AppendLine("}");
                
                if (!String.IsNullOrEmpty(classInfo.Namespace))
                {
                    source.AppendLine("}");
                }
                
                context.AddSource(
                    classInfo.Name + ".gen.cs",
                    source.ToString()
                );
            }
        }
    }
}

public class BindableAttributeReceiver : ISyntaxReceiver
{
    public class ClassInfo
    {
        public ClassDeclarationSyntax ClassNode;
        public string Name;
        public string Namespace;
        public string TargetType;
    }

    public List<ClassInfo> ClassesWithAttributes = new();

    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        if (syntaxNode is not ClassDeclarationSyntax classNode) return;

        bool hasAttribute = false;
        foreach (var attribute in classNode.AttributeLists)
        {
            foreach (var attr in attribute.Attributes)
            {
                // TODO: Create and inject 'GenerateMVVMBinding' via source generator
                if (attr.Name is IdentifierNameSyntax { Identifier.Text: "GenerateMVVMBinding" })
                {
                    Console.WriteLine("[CLASS] " + classNode);
                    hasAttribute = true;
                    break;
                }
            }

            if (hasAttribute)
            {
                break;
            }
        }

        if (hasAttribute)
        {
            var namespaceName = "";
            if (classNode.Parent is NamespaceDeclarationSyntax namespaceNode)
            {
                namespaceName = namespaceNode.Name.ToFullString();
            }

            ClassesWithAttributes.Add(
                new ClassInfo
                {
                    ClassNode = classNode,
                    Name = classNode.Identifier.Text,
                    Namespace = namespaceName
                }
            );
            Console.WriteLine($"[COLLECT] {namespaceName}::{classNode.Identifier.Text}");
        }
    }
}
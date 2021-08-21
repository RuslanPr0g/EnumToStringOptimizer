﻿using Microsoft.CodeAnalysis;
using System.Text;

namespace EnumToStringOptimizer
{
    [Generator]
    public class SourceGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new EnumSyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxReceiver is EnumSyntaxReceiver receiver)
            {
                var enums = receiver.Enums;
                var model = EnumsModelCollector.Collect(enums);
                string source = EnumClassCreator.Create(model);
                source = PrefixAsAutogenerated(source);
                context.AddSource("EnumExtensions.cs", source);
            }
        }

        private static string PrefixAsAutogenerated(string source)
        {
            StringBuilder sourceBuilder = new();
            sourceBuilder.AppendLine("// <auto-generated/>");
            sourceBuilder.AppendLine();
            sourceBuilder.Append(source);
            return sourceBuilder.ToString();
        }
    }
}
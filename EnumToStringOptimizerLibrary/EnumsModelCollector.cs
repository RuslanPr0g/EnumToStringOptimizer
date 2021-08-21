using EnumToStringOptimizer.Common;
using EnumToStringOptimizer.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace EnumToStringOptimizer
{
    public static class EnumsModelCollector
    {
        public static EnumsModel Collect(List<EnumDeclarationSyntax> syntaxes)
        {
            List<EnumModel> enums = new();
            foreach (var syntax in syntaxes)
            {
                var model = new EnumModel
                {
                    EnumName = syntax.Identifier.Text,
                    EnumMembers = syntax.Members
                                .Select(x => x.Identifier.Text)
                                .ToList(),
                    Namespace = SyntaxExtentions.GetNamespaceOrNull(syntax)
                };
                enums.Add(model);
            }

            return new EnumsModel
            {
                Enums = enums
            };
        }
    }
}

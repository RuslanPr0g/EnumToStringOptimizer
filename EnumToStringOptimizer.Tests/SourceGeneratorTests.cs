using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace EnumToStringOptimizer.Tests
{
    public class SourceGeneratorTests
    {
        [Fact]
        public void Execute_ShouldNotThrow_WhenRequestsExist()
        {
            // Arrange
            List<string> sources = new()
            {
                @"
using System;

namespace EnumToStringOptimizer.Tests
{
    public enum Role
    {
        Admin, User
    }
}
",
                @"
using System;

namespace EnumToStringOptimizer.Tests.Types
{
    public enum MediaType
    {
        Image, Video
    }
}
",
                @"
using System;

namespace EnumToStringOptimizer.Tests.Types
{
    public class TestType
    {
        public enum Variant
        {
            One, Two
        }
    }
}
"
            };
            Compilation inputCompilation = CreateCompilation(sources);
            SourceGenerator generator = new();
            GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);
            // Act
            driver = driver.RunGeneratorsAndUpdateCompilation(inputCompilation, out var outputCompilation, out var diagnostics);
            GeneratorDriverRunResult _ = driver.GetRunResult();
            // Assert
            // do not throws
        }

        private static Compilation CreateCompilation(List<string> sources)
        {
            return CSharpCompilation.Create("compilation",
                sources.Select(source => CSharpSyntaxTree.ParseText(source)),
                new[] { MetadataReference.CreateFromFile(typeof(Binder).GetTypeInfo().Assembly.Location) },
                new CSharpCompilationOptions(OutputKind.ConsoleApplication));
        }
    }
}

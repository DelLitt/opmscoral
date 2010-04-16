using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Text;
using Microsoft.CSharp;
using NMG.Core;
using NMG.Core.Domain;
using NUnit.Framework;
using CodeGenerator = NMG.Core.Generator.CodeGenerator;

namespace NMG.Tests.Generator
{
    [TestFixture]
    public class CodeGeneratorTest
    {
        [Test]
        public void ShouldCreateCompleteCompileUnit()
        {
            var applicationPreferences = new ApplicationPreferences
                                             {
                                                 NameSpace = "someNamespace",
                                                 TableName = "someTableName"
                                             };
            var codeGenerator = new CodeGenerator(applicationPreferences, new ColumnDetails());
            CodeCompileUnit pkClass;
            var codeCompileUnit = codeGenerator.GetCompileUnit(out pkClass);
            var cSharpCodeProvider = new CSharpCodeProvider();
            var stringBuilder = new StringBuilder();
            cSharpCodeProvider.GenerateCodeFromCompileUnit(codeCompileUnit, new StringWriter(stringBuilder), new CodeGeneratorOptions());
            Assert.IsTrue(stringBuilder.ToString().Contains("namespace someNamespace"));
            Assert.IsTrue(stringBuilder.ToString().Contains("public class someTableName"));
            Assert.IsTrue(stringBuilder.ToString().Contains("public someTableName()"));
        }
    }
}
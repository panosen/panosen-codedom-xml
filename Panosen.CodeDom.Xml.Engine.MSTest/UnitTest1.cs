using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.Xml.Engine.MSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            XmlNode node = new XmlNode { Name = "Project", NewLineBeforeEnd = true };
            node.AddAttribute("Sdk", "Microsoft.NET.Sdk");

            for (int i = 0; i < 3; i++)
            {
                node.AddAttribute($"p{i}", $"v{i}");
            }

            for (int i = 0; i < 3; i++)
            {
                var propertyGroup = new XmlNode { Name = "PropertyGroup", NewLineBeforeNode = true };
                node.AddChild(propertyGroup);

                for (int j = 0; j < 3; j++)
                {
                    propertyGroup.AddChild(new XmlNode { Name = "TargetFrameworks", Content = "net452" });
                }
            }

            XmlCodeEngine generator = new XmlCodeEngine();

            StringBuilder builder = new StringBuilder();

            generator.Generate(node, new StringWriter(builder), new GenerateOptions
            {
                AttribuesPerLine = 1
            });

            var actual = builder.ToString();

            var expected = PrepareExpected();

            Assert.AreEqual(expected, actual);
        }

        private string PrepareExpected()
        {
            return @"<Project Sdk=""Microsoft.NET.Sdk""
        p0=""v0""
        p1=""v1""
        p2=""v2"">

    <PropertyGroup>
        <TargetFrameworks>net452</TargetFrameworks>
        <TargetFrameworks>net452</TargetFrameworks>
        <TargetFrameworks>net452</TargetFrameworks>
    </PropertyGroup>

    <PropertyGroup>
        <TargetFrameworks>net452</TargetFrameworks>
        <TargetFrameworks>net452</TargetFrameworks>
        <TargetFrameworks>net452</TargetFrameworks>
    </PropertyGroup>

    <PropertyGroup>
        <TargetFrameworks>net452</TargetFrameworks>
        <TargetFrameworks>net452</TargetFrameworks>
        <TargetFrameworks>net452</TargetFrameworks>
    </PropertyGroup>

</Project>
";
        }
    }
}

using FluentAssert;
using System.Text;
using TraceryNet;
using Xunit;

namespace Tests.Unit_Tests
{
    public class YamlTests
    {
        [Fact]
        public void YamlTests_HelloWorld_HelloWorld()
        {
            // Arrange
            var yaml = new StringBuilder();
            yaml.AppendLine("---");
            yaml.AppendLine("origin: '#sentence#'");
            yaml.AppendLine("sentence: 'Hello world'");

            // Act
            var grammar = new Grammar(yaml.ToString());

            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("Hello world");
        }

        [Fact]
        public void YamlTests_IncreasedExpansionDepth_HelloWorld()
        {
            // Arrange
            var yaml = new StringBuilder();
            yaml.AppendLine("---");
            yaml.AppendLine("origin: '#sentence#'");
            yaml.AppendLine("sentence: '#greeting# #place#'");
            yaml.AppendLine("place:");
            yaml.AppendLine("  - 'world'");
            yaml.AppendLine("greeting:");
            yaml.AppendLine("  - 'Hello'");

            // Act
            var grammar = new Grammar(yaml.ToString());

            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("Hello world");
        }
    }
}

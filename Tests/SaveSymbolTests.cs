using FluentAssert;
using Xunit;

namespace Tests
{
    public class SaveSymbolTests
    {
        [Fact]
        public void SaveSymbol_NoExpansionSymbol_Saves()
        {
            // Arrange
            var json = "{" +
                       "    'origin': '#[hero:Alfred]story#'," +
                       "    'story': 'His name was #hero#.'" +
                       "}";

            var grammar = new TraceryNet.Grammar(json);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("His name was Alfred.");
        }

        [Fact]
        public void SaveSymbol_OneExpansionSymbol_Saves()
        {
            // Arrange
            var json = "{" +
                       "    'origin': '#[hero:#name#]story#'," +
                       "    'name': 'Alfred'," +
                       "    'story': 'His name was #hero#.'" +
                       "}";

            var grammar = new TraceryNet.Grammar(json);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output .ShouldBeEqualTo("His name was Alfred.");
        }

        [Fact]
        public void SaveSymbol_NoExpansionSymbolWithModifier_Saves()
        {
            // Arrange
            var json = "{" +
                       "    'origin': '#[hero:alfred]story#'," +
                       "    'story': 'His name was #hero.capitalize#.'" +
                       "}";

            var grammar = new TraceryNet.Grammar(json);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("His name was Alfred.");
        }

        [Fact]
        public void SaveSymbol_OneLevelDeep_Saves()
        {
            // Arrange
            var json = "{" +
                       "    'origin': '#[setName]name#'," +
                       "	'setName': '[name:Luigi]'," +
                       "}";

            var grammar = new TraceryNet.Grammar(json);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("Luigi");
        }

        [Fact]
        public void SaveSymbol_TwoLevelsDeep_Saves()
        {
            // Arrange
            var json = "{" +
                       "    'origin': '#[setName]name#'," +
                       "	'setName': '[name:#maleNames#]'," +
                       "	'maleNames': 'Mario'" +
                       "}";

            var grammar = new TraceryNet.Grammar(json);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("Mario");
        }
    }
}
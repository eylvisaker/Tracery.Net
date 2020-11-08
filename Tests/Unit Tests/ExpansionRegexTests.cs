using FluentAssert;
using TraceryNet;
using Xunit;

namespace Tests.Unit_Tests
{
    public class ExpansionRegexTests
    {
        [Fact]
        public void ExpansionRegex_OneMatchNoModifiers_OneMatch()
        {
            // Arrange
            var rule = "#colour#";

            // Act
            var matches = Grammar.ExpansionRegex.Matches(rule);

            // Assert
            matches.Count.ShouldBeEqualTo(1);
            matches[0].Value.ShouldBeEqualTo("#colour#");
        }

        [Fact]
        public void ExpansionRegex_TwoMatchesNoModifiers_TwoMatches()
        {
            // Arrange
            var rule = "#colour# #animal#";

            // Act
            var matches = Grammar.ExpansionRegex.Matches(rule);

            // Assert
            matches.Count.ShouldBeEqualTo(2);
            matches[0].Value.ShouldBeEqualTo("#colour#");
            matches[1].Value.ShouldBeEqualTo("#animal#");
        }

        [Fact]
        public void ExpansionRegex_OneMatchOneModifier_OneMatch()
        {
            // Arrange
            var rule = "#animal.capitalize#";

            // Act
            var matches = Grammar.ExpansionRegex.Matches(rule);

            // Assert
            matches.Count.ShouldBeEqualTo(1);
            matches[0].Value.ShouldBeEqualTo("#animal.capitalize#");
        }

        [Fact]
        public void ExpansionRegex_FourMatchesSentence_FourMatches()
        {
            // Arrange
            var rule = "The #animal# was #adjective.comma# #adjective.comma# and #adjective#.";

            // Act
            var matches = Grammar.ExpansionRegex.Matches(rule);

            // Assert
            matches.Count.ShouldBeEqualTo(4);
            matches[0].Value.ShouldBeEqualTo("#animal#");
            matches[1].Value.ShouldBeEqualTo("#adjective.comma#");
            matches[2].Value.ShouldBeEqualTo("#adjective.comma#");
            matches[3].Value.ShouldBeEqualTo("#adjective#");
        }

        [Fact]
        public void ExpansionRegex_OneMatchSaveSymbol_OneMatch()
        {
            // Arrange
            var rule = "#[hero:#name#][heroPet:#animal#]story#";

            // Act
            var matches = Grammar.ExpansionRegex.Matches(rule);

            // Assert
            matches.Count.ShouldBeEqualTo(1);

            // Even though there's sub-expansion symbols, it should only match once around
            // the whole thing.
            matches[0].Value.ShouldBeEqualTo("#[hero:#name#][heroPet:#animal#]story#");
        }
    }
}
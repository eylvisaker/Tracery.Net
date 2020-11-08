
using FluentAssert;
using Xunit;

namespace Tests.Unit_Tests
{
    public class FlattenTests
    {
        [Fact]
        public void Flatten_HelloWorld_Success()
        {
            // Arrange
            var json = "{" +
                       "    'origin': 'hello world'" +
                       "}";

            var grammar = new TraceryNet.Grammar(json);
            
            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("hello world");
        }

        [Fact]
        public void Flatten_ExpandSymbol_Animal()
        {
            // Arrange
            var json = "{" +
                       "    'origin': 'hello #animal#'," +
                       "    'animal': 'cat'" +
                       "}";

            var grammar = new TraceryNet.Grammar(json);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("hello cat");
        }

        [Fact]
        public void Flatten_Capitalize_FirstLetterCapitalized()
        {
            // Arrange
            var json = "{" +
                       "    'origin': 'hello #animal.capitalize#'," +
                       "    'animal': 'cat'" +
                       "}";

            var grammar = new TraceryNet.Grammar(json);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("hello Cat");
        }

        [Fact]
        public void Flatten_BeeSpeak_Beezz()
        {
            // Arrange
            var json = "{" +
                       "    'origin': '#animal.beeSpeak# are very important'," +
                       "    'animal': 'bees'" +
                       "}";

            var grammar = new TraceryNet.Grammar(json);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("beezzz are very important");
        }

        [Fact]
        public void Flatten_Comma_HelloCommaWorld()
        {
            // Arrange
            var json = "{" +
                       "    'origin': '#greeting.comma# #place#'," +
                       "    'greeting': 'Hello'," +
                       "    'place': 'world'" +
                       "}";

            var grammar = new TraceryNet.Grammar(json);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("Hello, world");
        }

        [Fact]
        public void Flatten_InQuotes_HelloQuoteWorldQuote()
        {
            // Arrange
            var json = "{" +
                       "    'origin': '#greeting# #place.inQuotes#'," +
                       "    'greeting': 'Hello'," +
                       "    'place': 'world'" +
                       "}";

            var grammar = new TraceryNet.Grammar(json);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("Hello \"world\"");
        }
        
        [Fact]
        public void Flatten_A_ACat()
        {
            // Arrange
            var json = "{" +
                       "    'origin': 'you are #animal.a#'," +
                       "    'animal': 'cat'" +
                       "}";

            var grammar = new TraceryNet.Grammar(json);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("you are a cat");
        }

        [Fact]
        public void Flatten_A_AnElephant()
        {
            // Arrange
            var json = "{" +
                       "    'origin': 'you are #animal.a#'," +
                       "    'animal': 'elephant'" +
                       "}";

            var grammar = new TraceryNet.Grammar(json);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("you are an elephant");
        }

        [Fact]
        public void Flatten_CaptitalizeA_ACat()
        {
            // Arrange
            var json = "{" +
                       "    'origin': 'you are #animal.capitalize.a#'," +
                       "    'animal': 'cat'" +
                       "}";

            var grammar = new TraceryNet.Grammar(json);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("you are a Cat");
        }

        [Fact]
        public void Flatten_ACaptitalize_ACat()
        {
            // Arrange
            var json = "{" +
                       "    'origin': 'you are #animal.a.capitalize#'," +
                       "    'animal': 'cat'" +
                       "}";

            var grammar = new TraceryNet.Grammar(json);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("you are A cat");
        }

        [Fact]
        public void Flatten_CaptitalizeAllCuteCat_CuteCat()
        {
            // Arrange
            var json = "{" +
                       "    'origin': 'you are a #animal.capitalizeAll#'," +
                       "    'animal': 'cute cat'" +
                       "}";

            var grammar = new TraceryNet.Grammar(json);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("you are a Cute Cat");
        }

        [Fact]
        public void Flatten_PastTensifyBully_Bullied()
        {
            // Arrange
            var json = "{" +
                       "    'origin': 'you #verb.ed#'," +
                       "    'verb': 'bully'" +
                       "}";

            var grammar = new TraceryNet.Grammar(json);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("you bullied");
        }

        [Fact]
        public void Flatten_PastTensifyQuack_Quacked()
        {
            // Arrange
            var json = "{" +
                       "    'origin': 'you #verb.ed#'," +
                       "    'verb': 'quack'" +
                       "}";

            var grammar = new TraceryNet.Grammar(json);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("you quacked");
        }

        [Fact]
        public void Flatten_PastTensifyCall_Called()
        {
            // Arrange
            var json = "{" +
                       "    'origin': 'you #verb.ed#?'," +
                       "    'verb': 'call'" +
                       "}";

            var grammar = new TraceryNet.Grammar(json);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("you called?");
        }
    }
}
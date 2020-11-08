using System;
using FluentAssert;
using Xunit;

namespace Tests.Unit_Tests
{
    public class CustomModifiersTest
    {
        [Fact]
        public void CustomModifiers_MakeEverythingHelloWorld_HelloWorld()
        {
            // Arrange
            var json = "{" +
                       "    'origin': '#sentence.helloWorld#'," +
                       "    'sentence': 'this sentence is irrelevant'" +
                       "}";

            Func<string, string> f = delegate (string i)
            {
                return "hello world";
            };

            var grammar = new TraceryNet.Grammar(json);
            grammar.AddModifier("helloWorld", f);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("hello world");
        }

        [Fact]
        public void CustomModifiers_Slurring_Slurring()
        {
            // Arrange
            var json = "{" +
                       "    'origin': '#sentence.slur#'," +
                       "    'sentence': 'this is a long sentence ready for slurring'" +
                       "}";

            Func<string, string> f = delegate (string i)
            {
                var o = "";
                var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

                foreach (char c in i)
                {
                    o += c;

                    if (Array.IndexOf(vowels, c) > -1)
                    {
                        o += c;
                    }
                }

                return o;
            };

            var grammar = new TraceryNet.Grammar(json);
            grammar.AddModifier("slur", f);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("thiis iis aa loong seenteencee reeaady foor sluurriing");
        }

        [Fact]
        public void CustomModifiers_ToUpper_ToUpper()
        {
            // Arrange
            var json = "{" +
                       "    'origin': '#sentence.toUpper#'," +
                       "    'sentence': 'hello cat'" +
                       "}";

            Func<string, string> f = delegate (string i)
            {
                return i.ToUpper();
            };

            var grammar = new TraceryNet.Grammar(json);
            grammar.AddModifier("toUpper", f);

            // Act
            var output = grammar.Flatten("#origin#");

            // Assert
            output.ShouldBeEqualTo("HELLO CAT");
        }
    }
}
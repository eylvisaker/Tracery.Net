using FluentAssert;
using System;
using TraceryNet;
using Xunit;

namespace Tests
{
    public class FlattenStringTest
    {
        private Grammar _grammar;
        private string _output;

        [Theory]
        [InlineData("hello")]
        [InlineData("disarm")]
        [InlineData("sky")]
        [InlineData("ragged")]
        [InlineData("sisters")]
        [InlineData("hunt")]
        [InlineData("Abstraction is often one floor above you.")]
        [InlineData("How was the math test?")]
        [InlineData("Cats are good pets, for they are clean and are not noisy.")]
        [InlineData("I want to buy a onesie… but know it won’t suit me.")]
        [InlineData("The shooter says goodbye to his love.")]
        [InlineData("There was no ice cream in the freezer, nor did they have money to go to the store.")]
        [InlineData("This is a Japanese doll.")]
        [InlineData("He said he was not there yesterday; however, many people saw him there.")]
        [InlineData("The river stole the gods.")]
        [InlineData("She was too short to see over the fence.")]
        [InlineData("Wow, does that work?")]
        [InlineData("She only paints with bold colors; she does not like pastels.")]
        [InlineData("Let me help you with your baggage.")]
        [InlineData("A purple pig and a green donkey flew a kite in the middle of the night and ended up sunburnt.")]
        public void FlattenString(string input)
        {
            GivenIHaveAStringToBeFlattened_(input);
            WhenIFlattenIt_();
            ThenItShouldReturn_(input);
        }
        
        public void GivenIHaveAStringToBeFlattened_(string input)
        {
            var json = "{" +
                       "    'origin': '" + input + "'" +
                       "}";

            _grammar = new Grammar(json);
        }
        
        public void WhenIFlattenIt_()
        {
            _output = _grammar.Flatten("#origin#");
        }
        
        public void ThenItShouldReturn_(string correctOutput)
        {
            _output.ShouldBeEqualTo(correctOutput);
        }
    }
}

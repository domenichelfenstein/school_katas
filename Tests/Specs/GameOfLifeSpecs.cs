namespace Tests.Specs
{
    using Application;
    using Application.Logic;
    using FluentAssertions;
    using Xunit;

    public class GameOfLifeSpecs
    {
        private readonly GameOfLife testee;

        public GameOfLifeSpecs()
        {
            this.testee = new GameOfLife();
        }

        [Theory]
        [InlineData(
@"
.....
.....
.ooo.
.....
.....",
@"
.....
..o..
..o..
..o..
.....")]
        [InlineData(
@"
.....
.o.o.
.ooo.
.....
.....",
@"
.....
.o.o.
.o.o.
..o..
.....")]
        public void NormalBehaviour(
            string input,
            string expectedResult)
        {
            var result = this.testee.NextStep(input);

            result.Should().Be(expectedResult);
        }
    }
}
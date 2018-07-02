namespace Tests
{
    using Application;
    using FluentAssertions;
    using Xunit;

    public class GameOfLifeSpecs
    {
        private readonly GameOfLife testee;

        public GameOfLifeSpecs()
        {
            this.testee = GameOfLifeBuilder.Build();
        }

        [Fact]
        public void NormalBehaviour()
        {
            var input = @"
.....
.....
.ooo.
.....
.....";
            var result = this.testee.NextStep(input);

            result.Should().Be(@"
.....
..o..
..o..
..o..
.....");
        }
    }
}
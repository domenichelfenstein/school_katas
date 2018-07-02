namespace Tests.Facts
{
    using Application;
    using FluentAssertions;
    using Xunit;

    public class SingleLineParserFacts
    {
        private readonly SingleLineParser testee;

        public SingleLineParserFacts()
        {
            this.testee = new SingleLineParser();
        }

        [Theory]
        [InlineData(
            "....",
            new[] { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead })]
        [InlineData(
            "o.o.",
            new[] { CellState.Alive, CellState.Dead, CellState.Alive, CellState.Dead })]
        public void SingleLine(
            string input,
            CellState[] expectedResult)
        {
            var result = this.testee.Parse(input);

            result.Should().BeEquivalentTo(
                expectedResult);
        }
    }
}
namespace Tests.Facts
{
    using Application;
    using Application.Data;
    using Application.Parsing;
    using FluentAssertions;
    using Xunit;

    public class MultiLineParserFacts
    {
        private readonly MultiLineParser testee;

        public MultiLineParserFacts()
        {
            this.testee = new MultiLineParser(
                new SingleLineParser());
        }

        [Fact]
        public void ParsesMultipleLines()
        {
            var input = @"
...
.o.";
            var expectedResult = new Grid(
                3,
                2,
                new[]
                {
                    (1, 1, CellState.Dead), (2, 1, CellState.Dead), (3, 1, CellState.Dead),
                    (1, 2, CellState.Dead), (2, 2, CellState.Alive), (3, 2, CellState.Dead)
                });

            var result = this.testee.Parse(input);

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
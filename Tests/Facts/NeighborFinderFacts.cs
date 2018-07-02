namespace Tests.Facts
{
    using System.Linq;
    using Application;
    using Application.Logic;
    using FluentAssertions;
    using Xunit;

    public class NeighborFinderFacts
    {
        private readonly NeighborFinder testee;

        public NeighborFinderFacts()
        {
            this.testee = new NeighborFinder();
        }

        [Theory]
        [InlineData("3x3", "2,2", new[] { "1,1", "1,2", "1,3", "2,1", "2,3", "3,1", "3,2", "3,3" })]
        [InlineData("3x3", "1,1", new[] { "1,2", "2,1", "2,2" })]
        [InlineData("3x3", "3,3", new[] { "2,2", "2,3", "3,2" })]
        [InlineData("4x5", "4,2", new[] { "3,1", "4,1", "3,2", "3,3", "4,3" })]
        public void GetNeighborsPositions(
            string grid,
            string position,
            string[] expectedNeighbors)
        {
            var actualGrid = grid.ToGrid();

            var actualPosition = position.ToPosition();

            var actualExpectedNeighbors = expectedNeighbors
                .Select(s => s.ToPosition());

            var result = this.testee.FindNeighbors(
                actualGrid,
                actualPosition);

            result.Should().BeEquivalentTo(
                actualExpectedNeighbors);
        }
    }
}
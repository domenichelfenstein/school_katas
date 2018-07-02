namespace Tests.Facts
{
    using Application;
    using FluentAssertions;
    using Xunit;

    public class GameEngineFacts
    {
        private readonly GameEngine testee;

        public GameEngineFacts()
        {
            this.testee = new GameEngine();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        public void LivingCell_Dies_WithLessThanTwoLivingNeighbors(
            int livingNeighbors)
        {
            var cell = CellState.Alive;

            var result = this.testee.GetNewState(
                cell,
                livingNeighbors);

            result.Should().Be(CellState.Dead);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void LivingCell_KeepsAlive_WithTwoOrThreeLivingNeighbors(
            int livingNeighbors)
        {
            var cell = CellState.Alive;

            var result = this.testee.GetNewState(
                cell,
                livingNeighbors);

            result.Should().Be(CellState.Alive);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(10)]
        public void LivingCell_Dies_WithMoreThanThreeLivingNeighbors(
            int livingNeighbors)
        {
            var cell = CellState.Alive;

            var result = this.testee.GetNewState(
                cell,
                livingNeighbors);

            result.Should().Be(CellState.Dead);
        }

        [Theory]
        [InlineData(3)]
        public void DeadCell_Lives_WithExactlyThreeLivingNeighbors(
            int livingNeighbors)
        {
            var cell = CellState.Dead;

            var result = this.testee.GetNewState(
                cell,
                livingNeighbors);

            result.Should().Be(CellState.Alive);
        }
    }
}
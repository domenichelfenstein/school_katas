namespace Application
{
    using System.Collections.Generic;
    using System.Linq;

    public class GameOfLife
    {
        private readonly MultiLineParser parser;
        private readonly NeighborFinder neighborFinder;
        private GameRules gameRules;

        public GameOfLife()
        {
            this.parser = new MultiLineParser(
                new SingleLineParser());

            this.neighborFinder = new NeighborFinder();

            this.gameRules = new GameRules();
        }

        public string NextStep(
            string input)
        {
            var grid = this.parser.Parse(input);

            var newCells = new List<(int X, int Y, CellState State)>();

            // Go through every Cell --> check
            foreach (var cell in grid)
            {
                // Find Neighbors --> check
                var neighborPositions = this.neighborFinder.FindNeighbors(
                    grid,
                    (cell.X, cell.Y));

                // Find number of living neighbors
                var numberOfLivingNeighbors = neighborPositions
                    .Select(p => grid.GetCell(p))
                    .Count(c => c.State == CellState.Alive);

                // Calculate new state (apply game rules) --> check
                var newState = this.gameRules.GetNewState(
                    cell.State,
                    numberOfLivingNeighbors);

                newCells.Add((cell.X, cell.Y, newState));
            }

            var newGrid = new Grid(
                grid.Width,
                grid.Height,
                newCells);

            return this.parser.Parse(newGrid);
        }
    }
}
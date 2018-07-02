namespace Application.Data
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Grid : IEnumerable<(int X, int Y, CellState State)>
    {
        public Grid(
            int width,
            int height,
            IReadOnlyCollection<(int X, int Y, CellState State)> cells)
        {
            this.Width = width;
            this.Height = height;
            this.Cells = cells;
        }

        public int Width { get; }

        public int Height { get; }

        public IReadOnlyCollection<(int X, int Y, CellState State)> Cells { get; }

        public IEnumerator<(int X, int Y, CellState State)> GetEnumerator() => this.Cells.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.Cells.GetEnumerator();

        public (int X, int Y, CellState State) GetCell((int X, int Y) position)
            => this.Cells
                .Single(c => c.X == position.X && c.Y == position.Y);
    }
}
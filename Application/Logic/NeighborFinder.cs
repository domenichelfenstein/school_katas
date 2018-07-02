namespace Application.Logic
{
    using System.Collections.Generic;
    using Application.Data;

    public class NeighborFinder
    {
        public IEnumerable<(int X, int Y)> FindNeighbors(
            Grid grid,
            (int X, int Y) position)
        {
            var minX = position.X > 1
                       ? position.X - 1
                       : 1;

            var maxX = position.X < grid.Width
                       ? position.X + 1
                       : grid.Width;

            var minY = position.Y > 1
                       ? position.Y - 1
                       : 1;
            var maxY = position.Y < grid.Height
                       ? position.Y + 1
                       : grid.Height;

            for (var x = minX; x <= maxX; x++)
            {
                for (var y = minY; y <= maxY; y++)
                {
                    var current = (x, y);
                    if (!current.Equals(position))
                    {
                        yield return (x, y);
                    }
                }
            }
        }
    }
}
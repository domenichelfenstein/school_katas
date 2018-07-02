namespace Application.Parsing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Application.Data;

    public class MultiLineParser
    {
        private readonly SingleLineParser singleLineParser;

        public MultiLineParser(SingleLineParser singleLineParser)
        {
            this.singleLineParser = singleLineParser;
        }

        public Grid Parse(string input)
        {
            var lines = input
                .Split(Environment.NewLine)
                .Skip(1)
                .Select(line => this.singleLineParser.Parse(line))
                .ToArray();

            var rows = lines.Length;
            var columns = lines.First().Length;

            return new Grid(
                columns,
                rows,
                GetCells()
                    .ToArray());

            IEnumerable<(int X, int Y, CellState State)> GetCells()
            {
                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < columns; x++)
                    {
                        yield return (x + 1, y + 1, lines[y][x]);
                    }
                }
            }
        }

        public string Parse(Grid grid)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();

            for (int y = 1; y <= grid.Height; y++)
            {
                for (int x = 1; x <= grid.Width; x++)
                {
                    var cell = grid.GetCell((x, y));
                    stringBuilder.Append(cell.State == CellState.Alive
                        ? "o"
                        : ".");
                }

                if (y != grid.Height)
                {
                    stringBuilder.AppendLine();
                }
            }

            return stringBuilder.ToString();
        }
    }
}
namespace Application
{
    using System;
    using System.Linq;

    public class SingleLineParser
    {
        public CellState[] Parse(
            string input)
        {
            return input
                .Select(this.Parse)
                .ToArray();
        }

        private CellState Parse(char input)
        {
            switch (input)
            {
                case '.':
                    return CellState.Dead;
                case 'o':
                    return CellState.Alive;
            }

            throw new NotImplementedException();
        }
    }
}
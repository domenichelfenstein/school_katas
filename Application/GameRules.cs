namespace Application
{
    public class GameRules
    {
        public CellState GetNewState(
            CellState cell,
            int livingNeighbors)
        {
            if (cell == CellState.Alive)
            {
                if (livingNeighbors >= 2 && livingNeighbors <= 3)
                {
                    return CellState.Alive;
                }
            }

            if (cell == CellState.Dead && livingNeighbors == 3)
            {
                return CellState.Alive;
            }

            return CellState.Dead;
        }
    }
}
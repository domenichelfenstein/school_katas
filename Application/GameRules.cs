namespace Application
{
    public class GameRules
    {
        public CellState GetNewState(
            CellState cell,
            int livingNeighbors)
        {
            if (livingNeighbors >= 2 && livingNeighbors <= 3)
            {
                return CellState.Alive;
            }

            return CellState.Dead;
        }
    }
}
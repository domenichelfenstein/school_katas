namespace Application
{
    public class GameEngine
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
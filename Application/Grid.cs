namespace Application
{
    using System.Collections.Generic;

    public class Grid : List<List<CellState>>
    {
    }

    public enum CellState
    {
        Dead = 10,
        Alive = 20
    }
}
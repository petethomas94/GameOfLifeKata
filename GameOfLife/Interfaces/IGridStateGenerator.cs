namespace GameOfLife.Interfaces
{
    using System.Collections.Generic;

    public interface IGridStateGenerator
    {
        List<List<Cell>> GenerateNextIteration(List<List<Cell>> grid, GridDimensions dimensions);
    }
}
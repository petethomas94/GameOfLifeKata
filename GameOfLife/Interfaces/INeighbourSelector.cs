namespace GameOfLife.Interfaces
{
    using System.Collections.Generic;

    public interface INeighbourSelector
    {
        Cell[] GetNeighbourCells(List<List<Cell>> grid, Coordinate cellCoordinate, CellPosition position);
    }
}
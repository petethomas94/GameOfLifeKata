namespace GameOfLife.Interfaces
{
    using System.Collections.Generic;

    public interface IGridDisplayGenerator
    {
        string GenerateGridDisplay(List<List<Cell>> grid, Coordinate cursor, List<Coordinate> seed);
        string GenerateGridDisplay(List<List<Cell>> grid, Coordinate cursor);
        string GenerateGridDisplay(List<List<Cell>> grid);
    }
}
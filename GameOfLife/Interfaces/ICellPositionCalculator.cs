namespace GameOfLife.Interfaces
{
    public interface    ICellPositionCalculator
    {
        CellPosition CalculateCellPosition(GridDimensions gridDimensions, Coordinate coordinate);
    }
}
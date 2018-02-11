namespace GameOfLife
{
    public interface    ICellPositionCalculator
    {
        CellPosition CalculateCellPosition(GridDimensions gridDimensions, Coordinate coordinate);
    }
}
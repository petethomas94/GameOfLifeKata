namespace GameOfLife
{
    public interface ICellPositionCalculator
    {
        CellPosition CalculateCellPosition(int xCoordinate, int yCoordinate);
    }
}
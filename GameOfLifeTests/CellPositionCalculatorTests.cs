namespace GameOfLifeTests
{
    using GameOfLife;
    using Xunit;

    public class CellPositionCalculatorTests
    {
        private CellPositionCalculator _sut = new CellPositionCalculator(new GridDimensions(10, 10));

        [Theory]
        [InlineData(0, 0, CellPosition.TopLeftCorner)]
        [InlineData(6, 0, CellPosition.TopEdge)]
        [InlineData(9, 0, CellPosition.TopRightCorner)]
        [InlineData(9, 5, CellPosition.RightEdge)]
        [InlineData(9, 9, CellPosition.BottomRightCorner)]
        [InlineData(5, 9, CellPosition.BottomEdge)]
        [InlineData(0, 9, CellPosition.BottomLeftCorner)]
        [InlineData(0, 6, CellPosition.LeftEdge)]
        [InlineData(6, 6, CellPosition.Centre)]
        public void CalculatesCellPosition(int xCoordinate, int yCoordinate, CellPosition expected)
        {
            var actual = _sut.CalculateCellPosition(xCoordinate, yCoordinate);

            Assert.Equal(expected, actual);
        }
    }
}

namespace GameOfLifeTests
{
    using GameOfLife;
    using Xunit;

    public class CellPositionCalculatorTests
    {
        private CellPositionCalculator _sut = new CellPositionCalculator();

        private GridDimensions dimensions = new GridDimensions(10,10);
        
        [Fact]
        public void TopLeftCorner()
        {
            var actual = _sut.CalculateCellPosition(dimensions, new Coordinate(0, 0));

            Assert.Equal(CellPosition.TopLeftCorner, actual);
        }

        [Fact]
        public void TopEdge()
        {
            var actual = _sut.CalculateCellPosition(dimensions, new Coordinate(6, 0));

            Assert.Equal(CellPosition.TopEdge, actual);
        }

        [Fact]
        public void TopRightCorner()
        {
            var actual = _sut.CalculateCellPosition(dimensions, new Coordinate(9, 0));

            Assert.Equal(CellPosition.TopRightCorner, actual);
        }

        [Fact]
        public void RightEdge()
        {
            var actual = _sut.CalculateCellPosition(dimensions, new Coordinate(9, 5));

            Assert.Equal(CellPosition.RightEdge, actual);
        }

        [Fact]
        public void BottomRightCorner()
        {
            var actual = _sut.CalculateCellPosition(dimensions, new Coordinate(9, 9));

            Assert.Equal(CellPosition.BottomRightCorner, actual);
        }

        [Fact]
        public void BottomEdge()
        {
            var actual = _sut.CalculateCellPosition(dimensions, new Coordinate(5, 9));

            Assert.Equal(CellPosition.BottomEdge, actual);
        }

        [Fact]
        public void BottomLeftCorner()
        {
            var actual = _sut.CalculateCellPosition(dimensions, new Coordinate(0, 9));

            Assert.Equal(CellPosition.BottomLeftCorner, actual);
        }

        [Fact]
        public void LeftEdge()
        {
            var actual = _sut.CalculateCellPosition(dimensions, new Coordinate(0, 6));

            Assert.Equal(CellPosition.LeftEdge, actual);
        }

        [Fact]
        public void Centre()
        {
            var actual = _sut.CalculateCellPosition(dimensions, new Coordinate(5, 5));

            Assert.Equal(CellPosition.Centre, actual);
        }
    }
}

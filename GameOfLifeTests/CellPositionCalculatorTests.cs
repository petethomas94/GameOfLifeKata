namespace GameOfLifeTests
{
    using GameOfLife;
    using Xunit;

    public class CellPositionCalculatorTests
    {
        private CellPositionCalculator _sut = new CellPositionCalculator(new GridDimensions(10, 10));

        //[Theory]
        //[InlineData(0, 0, CellPosition.TopLeftCorner)]
        //[InlineData(6, 0, CellPosition.TopEdge)]
        //[InlineData(9, 0, CellPosition.TopRightCorner)]
        //[InlineData(9, 5, CellPosition.RightEdge)]
        //[InlineData(9, 9, CellPosition.BottomRightCorner)]
        //[InlineData(5, 9, CellPosition.BottomEdge)]
        //[InlineData(0, 9, CellPosition.BottomLeftCorner)]
        //[InlineData(0, 6, CellPosition.LeftEdge)]
        //[InlineData(6, 6, CellPosition.Centre)]
        //public void CalculatesCellPosition(int xCoordinate, int yCoordinate, CellPosition expected)
        //{
        //    var actual = _sut.CalculateCellPosition(xCoordinate, yCoordinate);

        //    Assert.Equal(expected, actual);
        //}

        [Fact]
        public void TopLeftCorner()
        {
            var actual = _sut.CalculateCellPosition(0, 0);

            Assert.Equal(CellPosition.TopLeftCorner, actual);
        }

        [Fact]
        public void TopEdge()
        {
            var actual = _sut.CalculateCellPosition(6, 0);

            Assert.Equal(CellPosition.TopEdge, actual);
        }

        [Fact]
        public void TopRightCorner()
        {
            var actual = _sut.CalculateCellPosition(9, 0);

            Assert.Equal(CellPosition.TopRightCorner, actual);
        }

        [Fact]
        public void RightEdge()
        {
            var actual = _sut.CalculateCellPosition(9, 5);

            Assert.Equal(CellPosition.RightEdge, actual);
        }

        [Fact]
        public void BottomRightCorner()
        {
            var actual = _sut.CalculateCellPosition(9, 9);

            Assert.Equal(CellPosition.BottomRightCorner, actual);
        }

        [Fact]
        public void BottomEdge()
        {
            var actual = _sut.CalculateCellPosition(5, 9);

            Assert.Equal(CellPosition.BottomEdge, actual);
        }

        [Fact]
        public void BottomLeftCorner()
        {
            var actual = _sut.CalculateCellPosition(0, 9);

            Assert.Equal(CellPosition.BottomLeftCorner, actual);
        }

        [Fact]
        public void LeftEdge()
        {
            var actual = _sut.CalculateCellPosition(0, 6);

            Assert.Equal(CellPosition.LeftEdge, actual);
        }

        [Fact]
        public void Centre()
        {
            var actual = _sut.CalculateCellPosition(5, 5);

            Assert.Equal(CellPosition.Centre, actual);
        }
    }
}

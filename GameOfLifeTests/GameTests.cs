namespace GameOfLifeTests
{
    using System.Collections.Generic;
    using GameOfLife;
    using Moq;
    using Xunit;

    public class GameTests
    {
        private Mock<INeighbourSelector> _neighbourSelector = new Mock<INeighbourSelector>();
        private GridDimensions _gridDimensions = new GridDimensions(10, 10);
        private GridGenerator _sut;

        public GameTests()
        {
            _sut = new GridGenerator(_neighbourSelector.Object, new CellPositionCalculator(_gridDimensions));
        }

        [Fact]
        public void NeighbourSelectorIsCalledCorrectNumberOfTimesWithCorrectParameters()
        {
            var grid = GridFactory.CreateGrid(_gridDimensions, new List<Coordinate>());

            var newGrid = _sut.GenerateNextIteration(grid);

            _neighbourSelector.Verify(ns => ns.GetNeighbourCells(
                It.IsAny<List<List<Cell>>>(),
                It.IsAny<Coordinate>(),
                CellPosition.TopLeftCorner), Times.Once);

            _neighbourSelector.Verify(ns => ns.GetNeighbourCells(
                It.IsAny<List<List<Cell>>>(),
                It.IsAny<Coordinate>(),
                CellPosition.TopRightCorner), Times.Once);

            _neighbourSelector.Verify(ns => ns.GetNeighbourCells(
                It.IsAny<List<List<Cell>>>(),
                It.IsAny<Coordinate>(),
                CellPosition.BottomLeftCorner), Times.Once);

            _neighbourSelector.Verify(ns => ns.GetNeighbourCells(
                It.IsAny<List<List<Cell>>>(),
                It.IsAny<Coordinate>(),
                CellPosition.BottomRightCorner), Times.Once);

            _neighbourSelector.Verify(ns => ns.GetNeighbourCells(
                It.IsAny<List<List<Cell>>>(),
                It.IsAny<Coordinate>(),
                CellPosition.TopEdge), Times.Exactly(8));

            _neighbourSelector.Verify(ns => ns.GetNeighbourCells(
                It.IsAny<List<List<Cell>>>(),
                It.IsAny<Coordinate>(),
                CellPosition.RightEdge), Times.Exactly(8));

            _neighbourSelector.Verify(ns => ns.GetNeighbourCells(
                It.IsAny<List<List<Cell>>>(),
                It.IsAny<Coordinate>(),
                CellPosition.LeftEdge), Times.Exactly(8));

            _neighbourSelector.Verify(ns => ns.GetNeighbourCells(
                It.IsAny<List<List<Cell>>>(),
                It.IsAny<Coordinate>(),
                CellPosition.BottomEdge), Times.Exactly(8));

            _neighbourSelector.Verify(ns => ns.GetNeighbourCells(
                It.IsAny<List<List<Cell>>>(),
                It.IsAny<Coordinate>(),
                CellPosition.Centre), Times.Exactly(64));
        }
    }
}
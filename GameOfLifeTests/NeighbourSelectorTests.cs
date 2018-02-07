namespace GameOfLifeTests
{
    using System.Collections.Generic;
    using System.Linq;
    using GameOfLife;
    using Xunit;

    public class NeighbourSelectorTests
    {
        private NeighbourSelector _sut = new NeighbourSelector();

        [Fact]
        private void SelectsCorrectCellsForTopLeftCorner()
        {
            var grid = GridFactory.CreateGrid(
                new GridDimensions(10, 10),
                new List<Coordinate>()
                {
                    new Coordinate(1, 1),
                    new Coordinate(1, 0),
                    new Coordinate(0, 1)
                });

            var actual = _sut.GetNeighbourCells(grid, new Coordinate(0, 0), CellPosition.TopLeftCorner);

            Assert.True(actual.All(c => c == Cell.Alive));
            Assert.Equal(3, actual.Length);
        }

        [Fact]
        private void SelectsCorrectCellsForTopRightCorner()
        {
            var grid = GridFactory.CreateGrid(
                new GridDimensions(10, 10),
                new List<Coordinate>()
                {
                    new Coordinate(8,0),
                    new Coordinate(8, 1),
                    new Coordinate(9, 1)
                });

            var actual = _sut.GetNeighbourCells(grid, new Coordinate(9, 0), CellPosition.TopRightCorner);

            Assert.True(actual.All(c => c == Cell.Alive));
            Assert.Equal(3, actual.Length);
        }

        [Fact]
        private void SelectsCorrectCellsForBottomRightCorner()
        {
            var grid = GridFactory.CreateGrid(
                new GridDimensions(10, 10),
                new List<Coordinate>()
                {
                    new Coordinate(9,8),
                    new Coordinate(8, 8),
                    new Coordinate(8, 9)
                });

            var actual = _sut.GetNeighbourCells(grid, new Coordinate(9, 9), CellPosition.BottomRightCorner);

            Assert.True(actual.All(c => c == Cell.Alive));
            Assert.Equal(3, actual.Length);
        }

        [Fact]
        private void SelectsCorrectCellsForBottomLeftCorner()
        {
            var grid = GridFactory.CreateGrid(
                new GridDimensions(10, 10),
                new List<Coordinate>()
                {
                    new Coordinate(0,8),
                    new Coordinate(1, 8),
                    new Coordinate(1, 9)
                });

            var actual = _sut.GetNeighbourCells(grid, new Coordinate(0, 9), CellPosition.BottomLeftCorner);

            Assert.True(actual.All(c => c == Cell.Alive));
            Assert.Equal(3, actual.Length);
        }

        [Fact]
        private void SelectsCorrectCellsForTopEdge()
        {
            var grid = GridFactory.CreateGrid(
                new GridDimensions(10, 10),
                new List<Coordinate>()
                {
                    new Coordinate(4,0),
                    new Coordinate(6, 0),
                    new Coordinate(4, 1),
                    new Coordinate(5, 1),
                    new Coordinate(6, 1)
                });

            var actual = _sut.GetNeighbourCells(grid, new Coordinate(5, 0), CellPosition.TopEdge);

            Assert.True(actual.All(c => c == Cell.Alive));
            Assert.Equal(5, actual.Length);
        }

        [Fact]
        private void SelectsCorrectCellsForBottomEdge()
        {
            var grid = GridFactory.CreateGrid(
                new GridDimensions(10, 10),
                new List<Coordinate>()
                {
                    new Coordinate(4,9),
                    new Coordinate(6, 9),
                    new Coordinate(4, 8),
                    new Coordinate(5, 8),
                    new Coordinate(6, 8)
                });

            var actual = _sut.GetNeighbourCells(grid, new Coordinate(5, 9), CellPosition.BottomEdge);

            Assert.True(actual.All(c => c == Cell.Alive));
            Assert.Equal(5, actual.Length);
        }

        [Fact]
        private void SelectsCorrectCellsForLeftEdge()
        {
            var grid = GridFactory.CreateGrid(
                new GridDimensions(10, 10),
                new List<Coordinate>()
                {
                    new Coordinate(0,4),
                    new Coordinate(0, 6),
                    new Coordinate(1, 4),
                    new Coordinate(1, 5),
                    new Coordinate(1, 6)
                });

            var actual = _sut.GetNeighbourCells(grid, new Coordinate(0, 5), CellPosition.LeftEdge);

            Assert.True(actual.All(c => c == Cell.Alive));
            Assert.Equal(5, actual.Length);
        }

        [Fact]
        private void SelectsCorrectCellsForRightEdge()
        {
            var grid = GridFactory.CreateGrid(
                new GridDimensions(10, 10),
                new List<Coordinate>()
                {
                    new Coordinate(9,4),
                    new Coordinate(9, 6),
                    new Coordinate(8, 4),
                    new Coordinate(8, 5),
                    new Coordinate(8, 6)
                });

            var actual = _sut.GetNeighbourCells(grid, new Coordinate(9, 5), CellPosition.RightEdge);

            Assert.True(actual.All(c => c == Cell.Alive));
            Assert.Equal(5, actual.Length);
        }

        [Fact]
        private void SelectsCorrectCellsForCentre()
        {
            var grid = GridFactory.CreateGrid(
                new GridDimensions(10, 10),
                new List<Coordinate>()
                {
                    new Coordinate(4, 4),
                    new Coordinate(5, 4),
                    new Coordinate(6, 4),
                    new Coordinate(4, 5),
                    new Coordinate(6, 5),
                    new Coordinate(4, 6),
                    new Coordinate(5, 6),
                    new Coordinate(6, 6),
                });

            var actual = _sut.GetNeighbourCells(grid, new Coordinate(5, 5), CellPosition.Centre);

            Assert.True(actual.All(c => c == Cell.Alive));
            Assert.Equal(8, actual.Length);
        }
    }
}

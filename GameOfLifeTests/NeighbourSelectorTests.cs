namespace GameOfLifeTests
{
    using System;
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
            var grid = new GridFactory().CreateGrid(
                new GridDimensions(10, 10),
                new List<Coordinate>()
                {
                    new Coordinate(1, 1),
                    new Coordinate(1, 0),
                    new Coordinate(0, 1)
                });

            var actual = _sut.GetNeighbourCells(grid, new Coordinate(0, 0), CellPosition.TopLeftCorner);

            Assert.True(actual.All(c => c.IsAlive()));
            Assert.Equal(3, actual.Length);
        }

        [Fact]
        private void SelectsCorrectCellsForTopRightCorner()
        {
            var grid = new GridFactory().CreateGrid(
                new GridDimensions(10, 10),
                new List<Coordinate>()
                {
                    new Coordinate(8,0),
                    new Coordinate(8, 1),
                    new Coordinate(9, 1)
                });

            var actual = _sut.GetNeighbourCells(grid, new Coordinate(9, 0), CellPosition.TopRightCorner);

            Assert.True(actual.All(c => c.IsAlive()));
            Assert.Equal(3, actual.Length);
        }

        [Fact]
        private void SelectsCorrectCellsForBottomRightCorner()
        {
            var grid = new GridFactory().CreateGrid(
                new GridDimensions(10, 10),
                new List<Coordinate>()
                {
                    new Coordinate(9,8),
                    new Coordinate(8, 8),
                    new Coordinate(8, 9)
                });

            var actual = _sut.GetNeighbourCells(grid, new Coordinate(9, 9), CellPosition.BottomRightCorner);

            Assert.True(actual.All(c => c.IsAlive()));
            Assert.Equal(3, actual.Length);
        }

        [Fact]
        private void SelectsCorrectCellsForBottomLeftCorner()
        {
            var grid = new GridFactory().CreateGrid(
                new GridDimensions(10, 10),
                new List<Coordinate>()
                {
                    new Coordinate(0,8),
                    new Coordinate(1, 8),
                    new Coordinate(1, 9)
                });

            var actual = _sut.GetNeighbourCells(grid, new Coordinate(0, 9), CellPosition.BottomLeftCorner);

            Assert.True(actual.All(c => c.IsAlive()));
            Assert.Equal(3, actual.Length);
        }
    }

    public class NeighbourSelector : INeighbourSelector
    {
        public Cell[] GetNeighbourCells(List<List<Cell>> grid, Coordinate cellCoordinate, CellPosition position)
        {
            switch (position)
            {
                case CellPosition.TopLeftCorner:
                    return new[]
                    {
                        grid[cellCoordinate.XCoordinate + 1][cellCoordinate.YCoordinate + 1],
                        grid[cellCoordinate.XCoordinate + 1][cellCoordinate.YCoordinate],
                        grid[cellCoordinate.XCoordinate][cellCoordinate.YCoordinate + 1],
                    };
                case CellPosition.TopEdge:
                    break;
                case CellPosition.TopRightCorner:
                    return new[]
                    {
                        grid[cellCoordinate.XCoordinate - 1][cellCoordinate.YCoordinate + 1],
                        grid[cellCoordinate.XCoordinate - 1][cellCoordinate.YCoordinate],
                        grid[cellCoordinate.XCoordinate][cellCoordinate.YCoordinate + 1],
                    };
                case CellPosition.RightEdge:
                    break;
                case CellPosition.BottomRightCorner:
                    return new[]
                    {
                        grid[cellCoordinate.XCoordinate][cellCoordinate.YCoordinate - 1],
                        grid[cellCoordinate.XCoordinate - 1][cellCoordinate.YCoordinate - 1],
                        grid[cellCoordinate.XCoordinate - 1][cellCoordinate.YCoordinate]
                    };
                case CellPosition.BottomEdge:
                    break;
                case CellPosition.BottomLeftCorner:
                    return new[]
                    {
                        grid[cellCoordinate.XCoordinate][cellCoordinate.YCoordinate - 1],
                        grid[cellCoordinate.XCoordinate + 1][cellCoordinate.YCoordinate - 1],
                        grid[cellCoordinate.XCoordinate + 1][cellCoordinate.YCoordinate]
                    };
                case CellPosition.LeftEdge:
                    break;
                case CellPosition.Centre:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(position), position, null);
            }

            return null;
        }
    }
}

namespace GameOfLife
{
    using System;
    using System.Collections.Generic;

    public class NeighbourSelector : INeighbourSelector
    {
        public Cell[] GetNeighbourCells(List<List<Cell>> grid, Coordinate cellCoordinate, CellPosition position)
        {
            switch (position)
            {
                case CellPosition.TopLeftCorner:
                    return TopLeftCornerNeighbours(grid, cellCoordinate);
                case CellPosition.TopEdge:
                    return TopEdgeNeighbours(grid, cellCoordinate);
                case CellPosition.TopRightCorner:
                    return TopRightCornerNeighbours(grid, cellCoordinate);
                case CellPosition.RightEdge:
                    return RightEdgeNeighbours(grid, cellCoordinate);
                case CellPosition.BottomRightCorner:
                    return BottomRightCornerNeighbours(grid, cellCoordinate);
                case CellPosition.BottomEdge:
                    return BottomEdgeNeighbours(grid, cellCoordinate);
                case CellPosition.BottomLeftCorner:
                    return BottomLeftCornerNeighbours(grid, cellCoordinate);
                case CellPosition.LeftEdge:
                    return LeftEdgeNeighbours(grid, cellCoordinate);
                case CellPosition.Centre:
                    return CentreNeighbours(grid, cellCoordinate);
                default:
                    throw new ArgumentOutOfRangeException(nameof(position), position, null);
            }
        }

        private static Cell[] CentreNeighbours(List<List<Cell>> grid, Coordinate cellCoordinate)
        {
            return new[]
            {
                grid[cellCoordinate.YCoordinate - 1][cellCoordinate.XCoordinate - 1],
                grid[cellCoordinate.YCoordinate][cellCoordinate.XCoordinate - 1],
                grid[cellCoordinate.YCoordinate + 1][cellCoordinate.XCoordinate - 1],
                grid[cellCoordinate.YCoordinate - 1][cellCoordinate.XCoordinate],
                grid[cellCoordinate.YCoordinate + 1][cellCoordinate.XCoordinate],
                grid[cellCoordinate.YCoordinate - 1][cellCoordinate.XCoordinate + 1],
                grid[cellCoordinate.YCoordinate][cellCoordinate.XCoordinate + 1],
                grid[cellCoordinate.YCoordinate + 1][cellCoordinate.XCoordinate + 1],
            };
        }

        private static Cell[] LeftEdgeNeighbours(List<List<Cell>> grid, Coordinate cellCoordinate)
        {
            return new[]
            {
                grid[cellCoordinate.YCoordinate - 1][cellCoordinate.XCoordinate],
                grid[cellCoordinate.YCoordinate + 1][cellCoordinate.XCoordinate],
                grid[cellCoordinate.YCoordinate - 1][cellCoordinate.XCoordinate + 1],
                grid[cellCoordinate.YCoordinate][cellCoordinate.XCoordinate + 1],
                grid[cellCoordinate.YCoordinate + 1][cellCoordinate.XCoordinate + 1],
            };
        }

        private static Cell[] BottomLeftCornerNeighbours(List<List<Cell>> grid, Coordinate cellCoordinate)
        {
            return new[]
            {
                grid[cellCoordinate.YCoordinate][cellCoordinate.XCoordinate + 1],
                grid[cellCoordinate.YCoordinate - 1][cellCoordinate.XCoordinate + 1],
                grid[cellCoordinate.YCoordinate - 1][cellCoordinate.XCoordinate]
            };
        }

        private static Cell[] BottomEdgeNeighbours(List<List<Cell>> grid, Coordinate cellCoordinate)
        {
            return new[]
            {
                grid[cellCoordinate.YCoordinate][cellCoordinate.XCoordinate + 1],
                grid[cellCoordinate.YCoordinate][cellCoordinate.XCoordinate - 1],
                grid[cellCoordinate.YCoordinate - 1][cellCoordinate.XCoordinate + 1],
                grid[cellCoordinate.YCoordinate - 1][cellCoordinate.XCoordinate],
                grid[cellCoordinate.YCoordinate - 1][cellCoordinate.XCoordinate - 1],
            };
        }

        private static Cell[] BottomRightCornerNeighbours(List<List<Cell>> grid, Coordinate cellCoordinate)
        {
            return new[]
            {
                grid[cellCoordinate.YCoordinate][cellCoordinate.XCoordinate - 1],
                grid[cellCoordinate.YCoordinate - 1][cellCoordinate.XCoordinate - 1],
                grid[cellCoordinate.YCoordinate - 1][cellCoordinate.XCoordinate]
            };
        }

        private static Cell[] RightEdgeNeighbours(List<List<Cell>> grid, Coordinate cellCoordinate)
        {
            return new[]
            {
                grid[cellCoordinate.YCoordinate - 1][cellCoordinate.XCoordinate],
                grid[cellCoordinate.YCoordinate + 1][cellCoordinate.XCoordinate],
                grid[cellCoordinate.YCoordinate - 1][cellCoordinate.XCoordinate - 1],
                grid[cellCoordinate.YCoordinate - 1][cellCoordinate.XCoordinate - 1],
                grid[cellCoordinate.YCoordinate - 1][cellCoordinate.XCoordinate - 1],
            };
        }

        private static Cell[] TopRightCornerNeighbours(List<List<Cell>> grid, Coordinate cellCoordinate)
        {
            return new[]
            {
                grid[cellCoordinate.YCoordinate][cellCoordinate.XCoordinate - 1],
                grid[cellCoordinate.YCoordinate + 1][cellCoordinate.XCoordinate - 1],
                grid[cellCoordinate.YCoordinate + 1][cellCoordinate.XCoordinate],
            };
        }

        private static Cell[] TopEdgeNeighbours(List<List<Cell>> grid, Coordinate cellCoordinate)
        {
            return new[]
            {
                grid[cellCoordinate.YCoordinate][cellCoordinate.XCoordinate - 1],
                grid[cellCoordinate.YCoordinate][cellCoordinate.XCoordinate + 1],
                grid[cellCoordinate.YCoordinate + 1][cellCoordinate.XCoordinate - 1],
                grid[cellCoordinate.YCoordinate + 1][cellCoordinate.XCoordinate],
                grid[cellCoordinate.YCoordinate + 1][cellCoordinate.XCoordinate + 1],
            };
        }

        private static Cell[] TopLeftCornerNeighbours(List<List<Cell>> grid, Coordinate cellCoordinate)
        {
            return new[]
            {
                grid[cellCoordinate.YCoordinate + 1][cellCoordinate.XCoordinate + 1],
                grid[cellCoordinate.YCoordinate + 1][cellCoordinate.XCoordinate],
                grid[cellCoordinate.YCoordinate][cellCoordinate.XCoordinate + 1],
            };
        }
    }
}
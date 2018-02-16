namespace GameOfLife
{
    using System.Collections.Generic;
    using Interfaces;

    public class GridStateGenerator : IGridStateGenerator
    {
        private readonly INeighbourSelector _neighbourSelector;
        private readonly ICellPositionCalculator _cellPositionCalculator;

        public GridStateGenerator(INeighbourSelector neighbourSelector, ICellPositionCalculator cellPositionCalculator)
        {
            _neighbourSelector = neighbourSelector;
            _cellPositionCalculator = cellPositionCalculator;
        }

        public List<List<Cell>> GenerateNextIteration(List<List<Cell>> grid, GridDimensions dimensions)
        {
            var newState = new List<List<Cell>>();

            TraverseRows(grid, dimensions, newState);

            return newState;
        }

        private void TraverseRows(List<List<Cell>> grid, GridDimensions dimensions, List<List<Cell>> newState)
        {
            for (var row = 0; row < grid.Count; row++)
            {
                newState.Add(new List<Cell>());

                TraverseColumns(grid, dimensions, newState, row);
            }
        }

        private void TraverseColumns(List<List<Cell>> grid, GridDimensions dimensions, List<List<Cell>> newState, int row)
        {
            for (var column = 0; column < grid[row].Count; column++)
            {
                var coordinate = new Coordinate(column, row);

                var position = _cellPositionCalculator.CalculateCellPosition(dimensions, coordinate);

                var neighbours = _neighbourSelector.GetNeighbourCells(grid, coordinate, position);

                newState[row].Add(grid[row][column].GetNextState(neighbours));
            }
        }
    }
}
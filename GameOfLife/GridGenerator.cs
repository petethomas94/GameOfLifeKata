namespace GameOfLife
{
    using System.Collections.Generic;

    public class GridGenerator
    {
        private readonly INeighbourSelector _neighbourSelector;
        private readonly ICellPositionCalculator _cellPositionCalculator;

        public GridGenerator(INeighbourSelector neighbourSelector, ICellPositionCalculator cellPositionCalculator)
        {
            _neighbourSelector = neighbourSelector;
            _cellPositionCalculator = cellPositionCalculator;
        }

        public List<List<Cell>> GenerateNextIteration(List<List<Cell>> grid)
        {
            var newState = new List<List<Cell>>();

            for (var y = 0; y < grid.Count; y++)
            {
                newState.Add(new List<Cell>());

                for (var x = 0; x < grid[y].Count; x++)
                {
                    var coordinate = new Coordinate(x, y);

                    var position = _cellPositionCalculator.CalculateCellPosition(coordinate.XCoordinate, coordinate.YCoordinate);

                    var neighbours = _neighbourSelector.GetNeighbourCells(grid, coordinate, position);

                    newState[y].Add(grid[y][x].GetNextState(neighbours));
                }
            }

            return newState;
        }
    }
}
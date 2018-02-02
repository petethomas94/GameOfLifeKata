namespace GameOfLife
{
    using System.Collections.Generic;

    public class Game
    {
        private readonly INeighbourSelector _neighbourSelector;
        private readonly ICellPositionCalculator _cellPositionCalculator;

        private List<List<Cell>> _grid;

        public Game(INeighbourSelector neighbourSelector, ICellPositionCalculator cellPositionCalculator, List<List<Cell>> grid)
        {
            _neighbourSelector = neighbourSelector;
            _cellPositionCalculator = cellPositionCalculator;
            _grid = grid;
        }

        public void GenerateNextIteration()
        {
            var newState = _grid;

            foreach (var column in _grid)
            {
                foreach (var cell in column)
                {
                    var coordinate = new Coordinate(_grid.IndexOf(column), column.IndexOf(cell));

                    var position = _cellPositionCalculator.CalculateCellPosition(coordinate.XCoordinate, coordinate.YCoordinate);

                    var neighbours = _neighbourSelector.GetNeighbourCells(_grid, coordinate, position);

                    newState[coordinate.XCoordinate][coordinate.YCoordinate] = new Cell(cell.GetNextState(neighbours));
                }
            }
        }
    }
}
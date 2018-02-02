namespace GameOfLifeTests
{
    using System.Collections.Generic;
    using GameOfLife;

    public class Coordinate
    {
        public Coordinate(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
    }

    public class Game
    {
        private readonly INeighbourSelector _neighbourSelector;

        private List<List<Cell>> _grid;

        public Game(INeighbourSelector neighbourSelector, List<List<Cell>> grid)
        {
            _neighbourSelector = neighbourSelector;
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

                    var neighbours = _neighbourSelector.GetNeighbourCells(_grid, coordinate);

                    newState[coordinate.XCoordinate][coordinate.YCoordinate] = new Cell(cell.GetNextState(neighbours));
                }
            }
        }
    }

    public interface INeighbourSelector
    {
        Cell[] GetNeighbourCells(List<List<Cell>> grid, Coordinate cellCoordinate);
    }
}
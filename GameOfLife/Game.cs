namespace GameOfLife
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

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
            var newState = new List<List<Cell>>();

            for (var y = 0; y < _grid.Count; y++)
            {
                newState.Add(new List<Cell>());

                for (var x = 0; x < _grid[y].Count; x++)
                {
                    var coordinate = new Coordinate(x, y);

                    var position = _cellPositionCalculator.CalculateCellPosition(coordinate.XCoordinate, coordinate.YCoordinate);

                    var neighbours = _neighbourSelector.GetNeighbourCells(_grid, coordinate, position);

                    newState[y].Add(_grid[y][x].GetNextState(neighbours));
                }
            }

            _grid = newState;
        }

        public void PrintBoard()
        {
            Console.Clear();

            for (var i = 0; i < _grid.Count; i++)
            {
                for (var j = 0; j < _grid[i].Count; j++)
                {
                    if (_grid[i][j] == Cell.Alive)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('x');
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write('o');
                    }
                }

                Console.Write('\n');
            }

            Thread.Sleep(400);
        }
    }
}
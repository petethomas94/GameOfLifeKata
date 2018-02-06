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

            for (var i = 0; i < _grid.Count; i++)
            {
                newState.Add(new List<Cell>());

                for (var j = 0; j < _grid[i].Count; j++)
                {
                    var coordinate = new Coordinate(i, j);

                    var position = _cellPositionCalculator.CalculateCellPosition(coordinate.XCoordinate, coordinate.YCoordinate);

                    var neighbours = _neighbourSelector.GetNeighbourCells(_grid, coordinate, position);

                    newState[i].Add(new Cell(_grid[i][j].GetNextState(neighbours)));
                }
            }

            _grid = newState;
        }

        public void PrintBoard()
        {
            for (var i = 0; i < _grid[0].Count; i++)
            {
                for (var j = 0; j < _grid.Count; j++)
                {
                    if (_grid[j][i].IsAlive())
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

            Console.Clear();
        }
    }
}
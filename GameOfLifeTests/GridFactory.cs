namespace GameOfLifeTests
{
    using System.Collections.Generic;
    using System.Linq;
    using GameOfLife;

    public class GridFactory
    {
        public List<List<Cell>> CreateGrid(GridDimensions gridDimensions, List<Coordinate> seed)
        {
            var grid = new List<List<Cell>>();

            for (int i = 0; i < gridDimensions.Width; i++)
            {
                grid.Add(new List<Cell>());

                for (int j = 0; j < gridDimensions.Width; j++)
                {
                    if (seed.Any(c => c.XCoordinate == i && c.YCoordinate == j))
                    {
                        grid[i].Add(new Cell(CellState.Alive));
                    }
                    else
                    {
                        grid[i].Add(new Cell(CellState.Dead));
                    }
                }
            }

            return grid;
        }
    }
}
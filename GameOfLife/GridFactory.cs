namespace GameOfLife
{
    using System.Collections.Generic;
    using System.Linq;

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
                        grid[i].Add(Cell.Alive);
                    }
                    else
                    {
                        grid[i].Add(Cell.Dead);
                    }
                }
            }

            return grid;
        }
    }
}
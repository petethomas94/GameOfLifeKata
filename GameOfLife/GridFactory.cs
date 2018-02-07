namespace GameOfLife
{
    using System.Collections.Generic;
    using System.Linq;

    public class GridFactory
    {
        public static List<List<Cell>> CreateGrid(GridDimensions gridDimensions, List<Coordinate> seed)
        {
            var grid = new List<List<Cell>>();

            for (int y = 0; y < gridDimensions.Height; y++)
            {
                grid.Add(new List<Cell>());

                for (int x = 0; x < gridDimensions.Width; x++)
                {
                    if (seed.Any(c => c.XCoordinate == x && c.YCoordinate == y))
                    {
                        grid[y].Add(Cell.Alive);
                    }
                    else
                    {
                        grid[y].Add(Cell.Dead);
                    }
                }
            }

            return grid;
        }
    }
}
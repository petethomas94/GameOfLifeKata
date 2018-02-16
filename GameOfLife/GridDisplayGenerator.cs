namespace GameOfLife
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;

    public class GridDisplayGenerator : IGridDisplayGenerator
    {
        public string GenerateGridDisplay(List<List<Cell>> grid, Coordinate cursor, List<Coordinate> seed)
        {
            var sb = new StringBuilder();

            for (var yCoord = 0; yCoord < grid.Count; yCoord++)
            {
                for (var xCoord = 0; xCoord < grid[yCoord].Count; xCoord++)
                {
                    if (grid[yCoord][xCoord] == Cell.Alive || CursorPosition(cursor, xCoord, yCoord) || SeedPosition(seed, xCoord, yCoord))
                    {
                        sb.Append('x');
                    }
                    else
                    {
                        sb.Append('o');
                    }
                }

                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        public string GenerateGridDisplay(List<List<Cell>> grid, Coordinate cursor)
        {
            return GenerateGridDisplay(grid, cursor, null);
        }

        public string GenerateGridDisplay(List<List<Cell>> grid)
        {
            return GenerateGridDisplay(grid, null, null);
        }

        private bool SeedPosition(List<Coordinate> seed, int xCoord, int yCoord)
        {
            if (seed == null)
            {
                return false;
            }

            return seed.Any(c => c.Column == xCoord && c.Row == yCoord);
        }

        private bool CursorPosition(Coordinate cursor, int xCoord, int yCoord)
        {
            if (cursor == null)
            {
                return false;
            }

            return xCoord == cursor.Column && yCoord == cursor.Row;
        }
    }
}
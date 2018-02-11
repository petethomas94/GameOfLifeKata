namespace GameOfLife
{
    using System.Collections.Generic;
    public class Grid{

        public List<List<Cell>> Cells;

        public GridDimensions Dimensions;

        public Grid(GridDimensions dimensions)
        {
            Cells = GridFactory.CreateGrid(dimensions);
            Dimensions = dimensions;
        }

        public void AddSeedCell(Coordinate coordinate)
        {
            Cells[coordinate.YCoordinate][coordinate.XCoordinate] = Cell.Alive;
        }
    }
}

namespace GameOfLifeTests
{
    using System.Collections.Generic;
    using GameOfLife;
    using Xunit;

    public class GridFactoryTests
    {
        [Fact]
        public void CreatesGridWithCorrectDimensionsAndCorrectCellStates()
        {
            var dimensions = new GridDimensions(10, 20);

            var grid = GridFactory.CreateGrid(dimensions, new List<Coordinate>
            {
                new Coordinate(5, 5),
                new Coordinate(7, 8)
            });

            Assert.Equal(dimensions.Width, grid[0].Count);
            Assert.Equal(dimensions.Height, grid.Count);

            Assert.Equal(Cell.Alive, grid[5][5]);
            Assert.Equal(Cell.Alive, grid[8][7]);
        }
    }
}

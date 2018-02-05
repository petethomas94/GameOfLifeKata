namespace GameOfLife
{
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var gridDimensions = new GridDimensions(20, 20);

            var grid = new GridFactory().CreateGrid(gridDimensions, new List<Coordinate>()
            {
                new Coordinate(5,5),
                new Coordinate(6,5),
                new Coordinate(5,4),
                new Coordinate(4,5),
                new Coordinate(4,4),
                new Coordinate(5,6),
            });

            var game = new Game(new NeighbourSelector(), new CellPositionCalculator(gridDimensions), grid);

            game.PrintBoard();

            for (int i = 0; i < 100; i++)
            {
                game.GenerateNextIteration();
                game.PrintBoard();
            }
        }
    }
}

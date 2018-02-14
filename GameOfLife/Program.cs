namespace GameOfLife
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class Program
    {
        private static GridDimensions _gridDimensions = new GridDimensions(15, 30);

        private static GridDisplayGenerator _gridDisplayGenerator = new GridDisplayGenerator();

        private static GridStateGenerator _gridStateGenerator = new GridStateGenerator(new NeighbourSelector(), new CellPositionCalculator());

        static void Main()
        {
            while (true)
            {
                var grid = new Grid(_gridDimensions, _gridStateGenerator, _gridDisplayGenerator);

                var game = new Game(new ConsolePrinter(), grid);

                game.AddSeedStateToBoard();

                var tcs = new CancellationTokenSource();

                var task = Task.Run(() => game.Start(tcs.Token), tcs.Token);

                Console.ReadKey();

                tcs.Cancel();

                task.Wait();

                Console.Clear();
            }
        }
    }
}

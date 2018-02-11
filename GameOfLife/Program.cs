namespace GameOfLife
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class Program
    {
        private static GridDimensions _gridDimensions = new GridDimensions(15, 30);

        private static GridDisplayGenerator _gridDisplayGenerator = new GridDisplayGenerator();

        static void Main()
        {
            while (true)
            {
                var gridGenerator = new GridGenerator(new NeighbourSelector(), new CellPositionCalculator());

                var game = new Game(gridGenerator, _gridDisplayGenerator, new ConsolePrinter(), _gridDimensions);

                var seed = game.GetSeedStateFromUser();

                var grid = GridFactory.CreateGrid(_gridDimensions, seed);                

                var tcs = new CancellationTokenSource();

                var task = Task.Run(() => game.Start(grid, tcs.Token), tcs.Token);

                Console.ReadKey();

                tcs.Cancel();

                task.Wait();

                Console.Clear();
            }
        }
    }

    public class ConsolePrinter : IConsolePrinter
    {
        public void OutputToConsole(string output)
        {
            foreach(var c in output){
                if(c == 'x'){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(c);
                    Console.ResetColor();
                }else{
                    Console.Write(c);
                }
            }
        }

        public void ClearConsole()
        {
            Console.Clear();
        }
    }
}

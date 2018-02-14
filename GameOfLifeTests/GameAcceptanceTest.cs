using System.Threading;
using System.Threading.Tasks;
using GameOfLife;
using Moq;
using Xunit;

namespace GameOfLifeTests
{
    public class GameAcceptanceTest
    {
        private readonly GridDimensions gridDimensions = new GridDimensions(5, 5);
        private readonly Mock<IConsolePrinter> printer = new Mock<IConsolePrinter>();
        private readonly CancellationTokenSource cts = new CancellationTokenSource();


        [Fact]
        public void OutputsCorrectGridToConsole()
        {

            var grid = new Grid(
                gridDimensions,
                new GridStateGenerator(
                    new NeighbourSelector(),
                    new CellPositionCalculator()
                ),
                new GridDisplayGenerator());

            var sut = new Game(
                printer.Object,
                grid
                );

            var task = Task.Run(() => sut.Start(cts.Token), cts.Token);

            Thread.Sleep(1600);

            cts.Cancel();

            printer.Verify(cp => cp.OutputToConsole(It.IsAny<string>()), Times.Exactly(3));
        }
    }
}

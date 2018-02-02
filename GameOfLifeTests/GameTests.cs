namespace GameOfLifeTests
{
    using GameOfLife;
    using Moq;

    public class GameTests
    {
        private readonly Game _sut;

        private Mock<INeighbourSelector> _neighbourSelector = new Mock<INeighbourSelector>();

        public GameTests()
        {

        }
    }
}
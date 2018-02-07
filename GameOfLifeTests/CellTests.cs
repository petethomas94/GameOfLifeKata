namespace GameOfLifeTests
{
    using GameOfLife;
    using Xunit;

    public class CellTests
    {
        [Fact]
        public void CellShouldDieWithFewerThanTwoLiveNeighbours()
        {
            var cell = Cell.Alive;

            var actual = cell.GetNextState(Cell.Alive, Cell.Dead, Cell.Dead);

            Assert.Equal(Cell.Dead, actual);
        }

        [Fact]
        public void CellWithTwoLiveNeighboursLivesToNextGeneration()
        {
            var cell = Cell.Alive;

            var actual = cell.GetNextState(Cell.Alive, Cell.Alive, Cell.Dead);

            Assert.Equal(Cell.Alive, actual);
        }

        [Fact]
        public void CellWithThreeLiveNeighboursLivesToNextGeneration()
        {
            var cell = Cell.Alive;

            var actual = cell.GetNextState(Cell.Alive, Cell.Alive, Cell.Alive);

            Assert.Equal(Cell.Alive, actual);
        }

        [Fact]
        public void CellWithMoreThanThreeLiveNeighboursDies()
        {
            var cell = Cell.Alive;

            var actual = cell.GetNextState(Cell.Alive, Cell.Alive, Cell.Alive, Cell.Alive);

            Assert.Equal(Cell.Dead, actual);
        }

        [Fact]
        public void DeadCellWithThreeLiveNeighboursBecomesLive()
        {
            var cell = Cell.Dead;

            var actual = cell.GetNextState(Cell.Alive, Cell.Alive, Cell.Alive);

            Assert.Equal(Cell.Alive, actual);
        }
    }
}

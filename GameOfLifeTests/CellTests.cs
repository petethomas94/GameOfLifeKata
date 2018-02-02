namespace GameOfLifeTests
{
    using GameOfLife;
    using Xunit;

    public class CellTests
    {
        [Fact]
        public void CellShouldDieWithFewerThanTwoLiveNeighbours()
        {
            var cell = new Cell(CellState.Alive);

            var actual = cell.GetNextState(new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead));

            Assert.Equal(CellState.Dead, actual);
        }

        [Fact]
        public void CellWithTwoLiveNeighboursLivesToNextGeneration()
        {
            var cell = new Cell(CellState.Alive);

            var actual = cell.GetNextState(new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Dead));

            Assert.Equal(CellState.Alive, actual);
        }

        [Fact]
        public void CellWithThreeLiveNeighboursLivesToNextGeneration()
        {
            var cell = new Cell(CellState.Alive);

            var actual = cell.GetNextState(new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive));

            Assert.Equal(CellState.Alive, actual);
        }

        [Fact]
        public void CellWithMoreThanThreeLiveNeighboursDies()
        {
            var cell = new Cell(CellState.Alive);

            var actual = cell.GetNextState(new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive));

            Assert.Equal(CellState.Dead, actual);
        }

        [Fact]
        public void DeadCellWithThreeLiveNeighboursBecomesLive()
        {
            var cell = new Cell(CellState.Dead);

            var actual = cell.GetNextState(new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive));

            Assert.Equal(CellState.Alive, actual);
        }
    }
}

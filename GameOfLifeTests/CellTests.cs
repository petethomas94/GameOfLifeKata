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

            cell.SetNextState(new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead));

            Assert.False(cell.IsAlive());
        }

        [Fact]
        public void CellWithTwoLiveNeighboursLivesToNextGeneration()
        {
            var cell = new Cell(CellState.Alive);

            cell.SetNextState(new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Dead));

            Assert.True(cell.IsAlive());
        }

        [Fact]
        public void CellWithThreeLiveNeighboursLivesToNextGeneration()
        {
            var cell = new Cell(CellState.Alive);

            cell.SetNextState(new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive));

            Assert.True(cell.IsAlive());
        }

        [Fact]
        public void CellWithMoreThanThreeLiveNeighboursDies()
        {
            var cell = new Cell(CellState.Alive);

            cell.SetNextState(new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive));

            Assert.False(cell.IsAlive());
        }

        [Fact]
        public void DeadCellWithThreeLiveNeighboursBecomesLive()
        {
            var cell = new Cell(CellState.Dead);

            cell.SetNextState(new Cell(CellState.Alive), new Cell(CellState.Alive), new Cell(CellState.Alive));

            Assert.True(cell.IsAlive());
        }
    }
}

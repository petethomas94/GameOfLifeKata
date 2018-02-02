namespace GameOfLife
{
    using System.Linq;

    public class Cell
    {
        private CellState State { get; set; }

        public Cell(CellState state)
        {
            State = state;
        }

        public void SetNextState(params Cell[] surroundingCells)
        {
            if (Underpopulated(surroundingCells) || Overpopulated(surroundingCells))
            {
                State = CellState.Dead;
            }

            if (ReadyToReproduce(surroundingCells))
            {
                State = CellState.Alive;
            }
        }

        private bool ReadyToReproduce(Cell[] surroundingCells)
        {
            return State == CellState.Dead && surroundingCells.Count(c => c.IsAlive()) == 3;
        }

        private static bool Overpopulated(Cell[] surroundingCells)
        {
            return surroundingCells.Count(c => c.IsAlive()) > 3;
        }

        private static bool Underpopulated(Cell[] surroundingCells)
        {
            return surroundingCells.Count(c => c.IsAlive()) < 2;
        }

        public bool IsAlive()
        {
            return State == CellState.Alive;
        }
    }
}

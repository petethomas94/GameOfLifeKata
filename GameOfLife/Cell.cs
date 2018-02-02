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

        public CellState GetNextState(params Cell[] surroundingCells)
        {
            if (Underpopulated(surroundingCells) || Overpopulated(surroundingCells))
            {
                return CellState.Dead;
            }

            if (ReadyToReproduce(surroundingCells))
            {
                return CellState.Alive;
            }

            return CellState.Alive;
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

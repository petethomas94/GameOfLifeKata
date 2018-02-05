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
            if (IsAlive())
            {
                if (Underpopulated(surroundingCells) || Overpopulated(surroundingCells))
                {
                    return CellState.Dead;
                }

                return CellState.Alive;
            }

            if (ReadyToReproduce(surroundingCells))
            {
                return CellState.Alive;
            }

            return CellState.Dead;
        }

        private bool ReadyToReproduce(Cell[] surroundingCells)
        {
            return surroundingCells.Count(c => c.IsAlive()) == 3;
        }

        private static bool Overpopulated(Cell[] surroundingCells)
        {
            return surroundingCells.Count(c => c.IsAlive()) >= 4;
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

namespace GameOfLife
{
    using System.Linq;

    public static class CellExtensions
    {
        public static Cell GetNextState(this Cell state, params Cell[] surroundingCells)
        {
            if (state == Cell.Alive)
            {
                if (Underpopulated(surroundingCells) || Overpopulated(surroundingCells))
                {
                    return Cell.Dead;
                }

                return Cell.Alive;
            }

            if (ReadyToReproduce(surroundingCells))
            {
                return Cell.Alive;
            }

            return Cell.Dead;
        }

        private static bool ReadyToReproduce(Cell[] surroundingCells)
        {
            return surroundingCells.Count(c => c == Cell.Alive) == 3;
        }

        private static bool Overpopulated(Cell[] surroundingCells)
        {
            return surroundingCells.Count(c => c == Cell.Alive) >= 4;
        }

        private static bool Underpopulated(Cell[] surroundingCells)
        {
            return surroundingCells.Count(c => c == Cell.Alive) < 2;
        }
    }
}

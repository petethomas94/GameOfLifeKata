namespace GameOfLife
{
    using Interfaces;

    public class CellPositionCalculator : ICellPositionCalculator
    {
        public CellPosition CalculateCellPosition(GridDimensions gridDimensions, Coordinate coordinate)
        {
            if (TopLeftCorner(coordinate))
            {
                return CellPosition.TopLeftCorner;
            }

            if (TopRightCorner(gridDimensions, coordinate))
            {
                return CellPosition.TopRightCorner;
            }

            if (BottomRightCorner(gridDimensions, coordinate))
            {
                return CellPosition.BottomRightCorner;
            }

            if (BottomLeftCorner(gridDimensions, coordinate))
            {
                return CellPosition.BottomLeftCorner;
            }

            if (TopEdge(gridDimensions, coordinate))
            {
                return CellPosition.TopEdge;
            }

            if (RightEdge(gridDimensions, coordinate))
            {
                return CellPosition.RightEdge;
            }

            if (BottomEdge(gridDimensions, coordinate))
            {
                return CellPosition.BottomEdge;
            }

            if (LeftEdge(gridDimensions, coordinate))
            {
                return CellPosition.LeftEdge;
            }

            return CellPosition.Centre;
        }

        private bool TopLeftCorner(Coordinate coordinate)
        {
            return coordinate.Column == 0 && coordinate.Row == 0;
        }

        private bool TopRightCorner(GridDimensions dimensions, Coordinate coordinate)
        {
            return coordinate.Column == dimensions.Width - 1 && coordinate.Row == 0;
        }

        private bool BottomRightCorner(GridDimensions dimensions, Coordinate coordinate)
        {
            return coordinate.Column == dimensions.Width - 1 && coordinate.Row == dimensions.Height - 1;
        }

        private bool BottomLeftCorner(GridDimensions dimensions, Coordinate coordinate)
        {
            return coordinate.Column == 0 && coordinate.Row == dimensions.Height - 1;
        }

        private bool TopEdge(GridDimensions dimensions, Coordinate coordinate)
        {
            return coordinate.Column < dimensions.Width - 1 && coordinate.Row == 0;
        }

        private bool RightEdge(GridDimensions dimensions, Coordinate coordinate)
        {
            return coordinate.Column == dimensions.Width - 1 && coordinate.Row < dimensions.Height - 1;
        }

        private bool BottomEdge(GridDimensions dimensions, Coordinate coordinate)
        {
            return coordinate.Column < dimensions.Width - 1 && coordinate.Row == dimensions.Height - 1;
        }

        private bool LeftEdge(GridDimensions dimensions, Coordinate coordinate)
        {
            return coordinate.Column == 0 && coordinate.Row < dimensions.Height - 1;
        }
    }
}
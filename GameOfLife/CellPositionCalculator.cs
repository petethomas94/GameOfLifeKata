namespace GameOfLife
{
    public class GridDimensions
    {
        public GridDimensions(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public int Height { get; set; }
        public int Width { get; set; }
    }

    public class CellPositionCalculator : ICellPositionCalculator
    {
        private readonly GridDimensions _dimensions;

        public CellPositionCalculator(GridDimensions dimensions)
        {
            _dimensions = dimensions;
        }

        public CellPosition CalculateCellPosition(int xCoordinate, int yCoordinate)
        {
            if (TopLeftCorner(xCoordinate, yCoordinate))
            {
                return CellPosition.TopLeftCorner;
            }

            if (TopRightCorner(xCoordinate, yCoordinate))
            {
                return CellPosition.TopRightCorner;
            }

            if (BottomRightCorner(xCoordinate, yCoordinate))
            {
                return CellPosition.BottomRightCorner;
            }

            if (BottomLeftCorner(xCoordinate, yCoordinate))
            {
                return CellPosition.BottomLeftCorner;
            }

            if (TopEdge(xCoordinate, yCoordinate))
            {
                return CellPosition.TopEdge;
            }

            if (RightEdge(xCoordinate, yCoordinate))
            {
                return CellPosition.RightEdge;
            }

            if (BottomEdge(xCoordinate, yCoordinate))
            {
                return CellPosition.BottomEdge;
            }

            if (LeftEdge(xCoordinate, yCoordinate))
            {
                return CellPosition.LeftEdge;
            }

            return CellPosition.Centre;
        }

        private bool TopLeftCorner(int xCoordinate, int yCoordinate)
        {
            return xCoordinate == 0 && yCoordinate == 0;
        }

        private bool TopRightCorner(int xCoordinate, int yCoordinate)
        {
            return xCoordinate == _dimensions.Width - 1 && yCoordinate == 0;
        }

        private bool BottomRightCorner(int xCoordinate, int yCoordinate)
        {
            return xCoordinate == _dimensions.Width - 1 && yCoordinate == _dimensions.Height - 1;
        }

        private bool BottomLeftCorner(int xCoordinate, int yCoordinate)
        {
            return xCoordinate == 0 && yCoordinate == _dimensions.Height - 1;
        }

        private bool TopEdge(int xCoordinate, int yCoordinate)
        {
            return xCoordinate < _dimensions.Width - 1 && yCoordinate == 0;
        }

        private bool RightEdge(int xCoordinate, int yCoordinate)
        {
            return xCoordinate == _dimensions.Width - 1 && yCoordinate < _dimensions.Height - 1;
        }

        private bool BottomEdge(int xCoordinate, int yCoordinate)
        {
            return xCoordinate < _dimensions.Width - 1 && yCoordinate == _dimensions.Height - 1;
        }

        private bool LeftEdge(int xCoordinate, int yCoordinate)
        {
            return xCoordinate == 0 && yCoordinate < _dimensions.Height - 1;
        }
    }
}
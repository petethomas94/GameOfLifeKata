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
}
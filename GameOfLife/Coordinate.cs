namespace GameOfLife
{
    public class Coordinate
    {
        public Coordinate(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
    }
}
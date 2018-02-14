namespace GameOfLife
{
    using System;

    public class Coordinate
    {
        public Coordinate(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public void UserInput(ConsoleKey instruction, GridDimensions dimensions)
        {
            switch (instruction)
            {
                case ConsoleKey.LeftArrow:
                    if (XCoordinate == 0)
                    {
                        XCoordinate = dimensions.Width - 1;
                    }
                    else
                    {
                        XCoordinate--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (XCoordinate == dimensions.Width - 1)
                    {
                        XCoordinate = 0;
                    }
                    else
                    {
                        XCoordinate++;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (YCoordinate == dimensions.Height - 1)
                    {
                        YCoordinate = 0;
                    }
                    else
                    {
                        YCoordinate++;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (YCoordinate == 0)
                    {
                        YCoordinate = dimensions.Height - 1;
                    }
                    else
                    {
                        YCoordinate--;
                    }
                    break;
            }
        }

    }
}
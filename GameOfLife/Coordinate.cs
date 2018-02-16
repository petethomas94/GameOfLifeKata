namespace GameOfLife
{
    using System;

    public class Coordinate
    {
        public Coordinate(int column, int row)
        {
            Column = column;
            Row = row;
        }

        public int Column { get; set; }

        public int Row { get; set; }

        public void Move(ConsoleKey instruction, GridDimensions dimensions)
        {
            switch (instruction)
            {
                case ConsoleKey.LeftArrow:
                    if (Column == 0)
                    {
                        Column = dimensions.Width - 1;
                    }
                    else
                    {
                        Column--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (Column == dimensions.Width - 1)
                    {
                        Column = 0;
                    }
                    else
                    {
                        Column++;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (Row == dimensions.Height - 1)
                    {
                        Row = 0;
                    }
                    else
                    {
                        Row++;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (Row == 0)
                    {
                        Row = dimensions.Height - 1;
                    }
                    else
                    {
                        Row--;
                    }
                    break;
            }
        }

    }
}
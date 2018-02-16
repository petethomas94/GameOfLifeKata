namespace GameOfLife
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Grid
    {
        private List<List<Cell>> _cells;

        private GridDimensions _dimensions;

        private readonly IGridStateGenerator _gridStateGenerator;
        private readonly IGridDisplayGenerator _displayGenerator;

        public Grid(GridDimensions dimensions, IGridStateGenerator gridStateGenerator, IGridDisplayGenerator displayGenerator)
        {
            _cells = GridFactory.CreateGrid(dimensions);
            _dimensions = dimensions;
            _gridStateGenerator = gridStateGenerator;
            _displayGenerator = displayGenerator;
        }

        private void AddSeedCell(Coordinate coordinate)
        {
            _cells[coordinate.Row][coordinate.Column] = Cell.Alive;
        }

        public void NextGeneration()
        {
            _cells = _gridStateGenerator.GenerateNextIteration(_cells, _dimensions);
        }

        public string GetDisplay(Coordinate cursor = null)
        {
            return _displayGenerator.GenerateGridDisplay(_cells, cursor);
        }

        public void HandleUserInput(ConsoleKey instruction, Coordinate cursor)
        {
            if (instruction == ConsoleKey.Spacebar)
            {
                AddSeedCell(new Coordinate(cursor.Column, cursor.Row));
                return;
            }

            cursor.Move(instruction, _dimensions);
        }
    }
}

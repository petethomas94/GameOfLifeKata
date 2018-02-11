namespace GameOfLifeTests
{
    using System;
    using System.Collections.Generic;
    using GameOfLife;
    using Xunit;

    public class GridDisplayGeneratorTests
    {
        [Fact]
        public void GeneratesCorrectDisplayForCompletelyDeadGrid()
        {
            var grid = new Grid(new GridDimensions(5, 5));

            var sut = new GridDisplayGenerator();

            var expected =
                $"ooooo{Environment.NewLine}ooooo{Environment.NewLine}ooooo{Environment.NewLine}ooooo{Environment.NewLine}ooooo{Environment.NewLine}";

            var actual = sut.GenerateGridDisplay(grid.Cells);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GeneratesCorrectDisplayForGridWithLiveCells()
        {
            var grid = new Grid(new GridDimensions(5, 5));

            grid.AddSeedCell(new Coordinate(0,0));
            grid.AddSeedCell(new Coordinate(4,1));
            grid.AddSeedCell(new Coordinate(3,4));

            var sut = new GridDisplayGenerator();

            var expected =
                $"xoooo{Environment.NewLine}oooox{Environment.NewLine}ooooo{Environment.NewLine}ooooo{Environment.NewLine}oooxo{Environment.NewLine}";

            var actual = sut.GenerateGridDisplay(grid.Cells);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GeneratesCorrectDisplayForCursorPosition()
        {
            var grid = new Grid(new GridDimensions(5, 5));

            var sut = new GridDisplayGenerator();

            var expected =
                $"ooooo{Environment.NewLine}ooooo{Environment.NewLine}ooxoo{Environment.NewLine}ooooo{Environment.NewLine}ooooo{Environment.NewLine}";

            var actual = sut.GenerateGridDisplay(grid.Cells, new Coordinate(2, 2));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GeneratesCorrectDisplayForCursorPositionAndSeed()
        {
            var grid = new Grid(new GridDimensions(5, 5));

            grid.AddSeedCell(new Coordinate(2,0));
            grid.AddSeedCell(new Coordinate(2,1));
            grid.AddSeedCell(new Coordinate(2,2));

            var sut = new GridDisplayGenerator();

            var expected =
                $"ooxoo{Environment.NewLine}ooxoo{Environment.NewLine}ooxoo{Environment.NewLine}ooooo{Environment.NewLine}ooooo{Environment.NewLine}";

            var actual = sut.GenerateGridDisplay(grid.Cells, new Coordinate(2, 2));

            Assert.Equal(expected, actual);
        }
    }
}

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
            var grid = GridFactory.CreateGrid(new GridDimensions(5, 5), new List<Coordinate>());

            var sut = new GridDisplayGenerator();

            var expected =
                $"ooooo{Environment.NewLine}ooooo{Environment.NewLine}ooooo{Environment.NewLine}ooooo{Environment.NewLine}ooooo{Environment.NewLine}";

            var actual = sut.GenerateGridDisplay(grid);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GeneratesCorrectDisplayForGridWithLiveCells()
        {
            var grid = GridFactory.CreateGrid(new GridDimensions(5, 5), new List<Coordinate>()
            {
                new Coordinate(0,0),
                new Coordinate(4,1),
                new Coordinate(3,4)
            });

            var sut = new GridDisplayGenerator();

            var expected =
                $"xoooo{Environment.NewLine}oooox{Environment.NewLine}ooooo{Environment.NewLine}ooooo{Environment.NewLine}oooxo{Environment.NewLine}";

            var actual = sut.GenerateGridDisplay(grid);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GeneratesCorrectDisplayForCursorPosition()
        {
            var grid = GridFactory.CreateGrid(new GridDimensions(5, 5), new List<Coordinate>());

            var sut = new GridDisplayGenerator();

            var expected =
                $"ooooo{Environment.NewLine}ooooo{Environment.NewLine}ooxoo{Environment.NewLine}ooooo{Environment.NewLine}ooooo{Environment.NewLine}";

            var actual = sut.GenerateGridDisplay(grid, new Coordinate(2, 2));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GeneratesCorrectDisplayForCursorPositionAndSeed()
        {
            var grid = GridFactory.CreateGrid(new GridDimensions(5, 5), new List<Coordinate>());

            var sut = new GridDisplayGenerator();

            var expected =
                $"ooxoo{Environment.NewLine}ooxoo{Environment.NewLine}ooxoo{Environment.NewLine}ooooo{Environment.NewLine}ooooo{Environment.NewLine}";

            var actual = sut.GenerateGridDisplay(grid, new Coordinate(2, 2), new List<Coordinate>()
            {
                new Coordinate(2,0),
                new Coordinate(2,1),
                new Coordinate(2,2),
            });

            Assert.Equal(expected, actual);
        }
    }
}

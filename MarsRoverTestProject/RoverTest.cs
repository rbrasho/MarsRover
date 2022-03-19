using MarsRover.Application;
using MarsRover.Common;
using MarsRover.Exceptions;
using MarsRover.Model;
using System;
using Xunit;

namespace MarsRoverTestProject
{
    public class RoverTest
    {
        [Fact]
        public void TurnLeft()
        {
            Rover rover = new Rover(new Coordinate(2, 3), Enum.Parse<DirectionEnum>("W"));
            rover.TurnLeft();
            Assert.True(rover.Direction==DirectionEnum.S);
        }
        [Fact]
        public void TurnRight()
        {
            Rover rover = new Rover(new Coordinate(2, 3), Enum.Parse<DirectionEnum>("W"));
            rover.TurnRight();
            Assert.True(rover.Direction == DirectionEnum.N);
        }
        [Fact]
        public void ExploreCaseOne()
        {
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Rover rover = new Rover(new Coordinate(1, 2), Enum.Parse<DirectionEnum>("N"));
            rover.Explore(plateau, "LMLMLMLMM");
            Assert.True(rover.Direction == DirectionEnum.N && rover.Coordinate.X == 1 && rover.Coordinate.Y==3);
        }

        [Fact]
        public void ExploreCaseTwo()
        {
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Rover rover = new Rover(new Coordinate(3, 3), Enum.Parse<DirectionEnum>("E"));
            rover.Explore(plateau, "MMRMMRMRRM");
            Assert.True(rover.Direction == DirectionEnum.E && rover.Coordinate.X == 5 && rover.Coordinate.Y == 1);
        }
        [Fact]
        public void ExploreCaseParameterError()
        {
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Rover rover = new Rover(new Coordinate(3, 3), Enum.Parse<DirectionEnum>("E"));
            var exception = Assert.Throws<WrongParameterException>(() => rover.Explore(plateau, "MMAMMMMM"));
            Assert.Equal(Constants.WarningWrongParameterString, exception.Message);
        }

        [Fact]
        public void ExploreCaseStringEmptyParameterError()
        {
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Rover rover = new Rover(new Coordinate(3, 3), Enum.Parse<DirectionEnum>("E"));
            var exception = Assert.Throws<ArgumentNullException>(() => rover.Explore(plateau, ""));
            Assert.Equal(new ArgumentNullException().Message, exception.Message);
        }
        [Fact]
        public void ExploreCaseStringNullParameterError()
        {
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Rover rover = new Rover(new Coordinate(3, 3), Enum.Parse<DirectionEnum>("E"));
            var exception = Assert.Throws<ArgumentNullException>(() => rover.Explore(plateau, null));
            Assert.Equal(new ArgumentNullException().Message, exception.Message);
        }
        [Fact]
        public void ExploreCaseParameterSpaceError()
        {
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Rover rover = new Rover(new Coordinate(3, 3), Enum.Parse<DirectionEnum>("E"));
            var exception = Assert.Throws<WrongParameterException>(() => rover.Explore(plateau, "MM MMMMM"));
            Assert.Equal(Constants.WarningWrongParameterString, exception.Message);
        }
        [Fact]
        public void ExploreCaseWrongMove()
        {
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Rover rover = new Rover(new Coordinate(3, 3), Enum.Parse<DirectionEnum>("E"));
            var exception = Assert.Throws<WrongMoveException>(() => rover.Explore(plateau, "MMMMMMMM"));
            Assert.Equal(Constants.WarningMoveString, exception.Message);
        }
        [Fact]
        public void ExploreCaseLongDataError()
        {
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Rover rover = new Rover(new Coordinate(1, 2), Enum.Parse<DirectionEnum>("N"));
            var exception = Assert.Throws<WrongMoveException>(() => rover.Explore(plateau, "MMRMMRMRRMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMM"));
            Assert.Equal(Constants.WarningMoveString, exception.Message);
        }
        [Fact]
        public void ExploreCaseLongData()
        {
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Rover rover = new Rover(new Coordinate(1, 2), Enum.Parse<DirectionEnum>("N"));
            rover.Explore( plateau, "LMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRM");
            Assert.True(rover.Direction == DirectionEnum.N && rover.Coordinate.X == 1 && rover.Coordinate.Y == 2);
        }
    }
}

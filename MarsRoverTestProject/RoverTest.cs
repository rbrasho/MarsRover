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
        public void TurnLeftWest()
        {
            Rover rover = new Rover(new Coordinate(2, 3), DirectionEnum.W);
            rover.TurnLeft();
            Assert.True(rover.Direction==DirectionEnum.S);
        }
        [Fact]
        public void TurnRightWest()
        {
            Rover rover = new Rover(new Coordinate(2, 3), DirectionEnum.W);
            rover.TurnRight();
            Assert.True(rover.Direction == DirectionEnum.N);
        }
        [Fact]
        public void TurnLeftSouth()
        {
            Rover rover = new Rover(new Coordinate(2, 3), DirectionEnum.S);
            rover.TurnLeft();
            Assert.True(rover.Direction == DirectionEnum.E);
        }
        [Fact]
        public void TurnRightSouth()
        {
            Rover rover = new Rover(new Coordinate(2, 3), DirectionEnum.S);
            rover.TurnRight();
            Assert.True(rover.Direction == DirectionEnum.W);
        }
        [Fact]
        public void TurnLeftEast()
        {
            Rover rover = new Rover(new Coordinate(2, 3), DirectionEnum.E);
            rover.TurnLeft();
            Assert.True(rover.Direction == DirectionEnum.N);
        }
        [Fact]
        public void TurnRightEast()
        {
            Rover rover = new Rover(new Coordinate(2, 3), DirectionEnum.E);
            rover.TurnRight();
            Assert.True(rover.Direction == DirectionEnum.S);
        }
        [Fact]
        public void TurnLeftNorth()
        {
            Rover rover = new Rover(new Coordinate(2, 3), DirectionEnum.N);
            rover.TurnLeft();
            Assert.True(rover.Direction == DirectionEnum.W);
        }
        [Fact]
        public void TurnRightNorth()
        {
            Rover rover = new Rover(new Coordinate(2, 3), DirectionEnum.N);
            rover.TurnRight();
            Assert.True(rover.Direction == DirectionEnum.E);
        }
        [Fact]
        public void ChangeCoordinateWest()
        {
            Rover rover = new Rover(new Coordinate(2, 3), DirectionEnum.W);
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            rover.ChangeCoordinate(plateau);
            Assert.True(rover.Coordinate.X == 1);
        }
        [Fact]
        public void ChangeCoordinateEast()
        {
            Rover rover = new Rover(new Coordinate(2, 3), DirectionEnum.E);
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            rover.ChangeCoordinate(plateau);
            Assert.True(rover.Coordinate.X == 3);
        }
        [Fact]
        public void ChangeCoordinateSouth()
        {
            Rover rover = new Rover(new Coordinate(2, 3), DirectionEnum.S);
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            rover.ChangeCoordinate(plateau);
            Assert.True(rover.Coordinate.Y == 2);
        }
        [Fact]
        public void ChangeCoordinateNorth()
        {
            Rover rover = new Rover(new Coordinate(2, 3), DirectionEnum.N);
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            rover.ChangeCoordinate(plateau);
            Assert.True(rover.Coordinate.Y == 4);
        }

        [Fact]
        public void AreaMovableFalse()
        {
            Rover rover = new Rover(new Coordinate(5, 5), DirectionEnum.N);
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Assert.True(plateau.Moveable(rover)==false);
        }
        [Fact]
        public void AreaMovableTrue()
        {
            Rover rover = new Rover(new Coordinate(5, 5), DirectionEnum.S);
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Assert.True(plateau.Moveable(rover) == true);
        }
        [Fact]
        public void ExploreCaseOne()
        {
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Rover rover = new Rover(new Coordinate(1, 2), DirectionEnum.N);
            rover.Explore(plateau, "LMLMLMLMM");
            Assert.True(rover.Direction == DirectionEnum.N && rover.Coordinate.X == 1 && rover.Coordinate.Y==3);
        }

        [Fact]
        public void ExploreCaseTwo()
        {
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Rover rover = new Rover(new Coordinate(3, 3), DirectionEnum.E);
            rover.Explore(plateau, "MMRMMRMRRM");
            Assert.True(rover.Direction == DirectionEnum.E && rover.Coordinate.X == 5 && rover.Coordinate.Y == 1);
        }
        [Fact]
        public void ExploreCaseParameterError()
        {
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Rover rover = new Rover(new Coordinate(3, 3), DirectionEnum.E);
            var exception = Assert.Throws<WrongParameterException>(() => rover.Explore(plateau, "MMAMMMMM"));
            Assert.Equal(Constants.WarningWrongParameterString, exception.Message);
        }

        [Fact]
        public void ExploreCaseStringEmptyParameterError()
        {
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Rover rover = new Rover(new Coordinate(3, 3), DirectionEnum.E);
            var exception = Assert.Throws<ArgumentNullException>(() => rover.Explore(plateau, ""));
            Assert.Equal(new ArgumentNullException().Message, exception.Message);
        }
        [Fact]
        public void ExploreCaseStringNullParameterError()
        {
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Rover rover = new Rover(new Coordinate(3, 3), DirectionEnum.E);
            var exception = Assert.Throws<ArgumentNullException>(() => rover.Explore(plateau, null));
            Assert.Equal(new ArgumentNullException().Message, exception.Message);
        }
        [Fact]
        public void ExploreCaseParameterSpaceError()
        {
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Rover rover = new Rover(new Coordinate(3, 3), DirectionEnum.E);
            var exception = Assert.Throws<WrongParameterException>(() => rover.Explore(plateau, "MM MMMMM"));
            Assert.Equal(Constants.WarningWrongParameterString, exception.Message);
        }
        [Fact]
        public void ExploreCaseWrongMove()
        {
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Rover rover = new Rover(new Coordinate(3, 3), DirectionEnum.E);
            var exception = Assert.Throws<WrongMoveException>(() => rover.Explore(plateau, "MMMMMMMM"));
            Assert.Equal(Constants.WarningMoveString, exception.Message);
        }
        [Fact]
        public void ExploreCaseLongDataError()
        {
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Rover rover = new Rover(new Coordinate(1, 2), DirectionEnum.N);
            var exception = Assert.Throws<WrongMoveException>(() => rover.Explore(plateau, "MMRMMRMRRMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMMLMLMLMLMM"));
            Assert.Equal(Constants.WarningMoveString, exception.Message);
        }
        [Fact]
        public void ExploreCaseLongData()
        {
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Rover rover = new Rover(new Coordinate(1, 2), DirectionEnum.N);
            rover.Explore( plateau, "LMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRM");
            Assert.True(rover.Direction == DirectionEnum.N && rover.Coordinate.X == 1 && rover.Coordinate.Y == 2);
        }
    }
}

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
        [Theory]
        [InlineData(DirectionEnum.W, DirectionEnum.S)]
        [InlineData(DirectionEnum.S, DirectionEnum.E)]
        [InlineData(DirectionEnum.E, DirectionEnum.N)]
        [InlineData(DirectionEnum.N, DirectionEnum.W)]
        public void TurnLeft(DirectionEnum current, DirectionEnum expected)
        {
            Rover rover = new Rover(new Coordinate(2, 3), current);
            rover.TurnLeft();
            Assert.True(rover.Direction == expected);
        }
        [Theory]
        [InlineData(DirectionEnum.W, DirectionEnum.N)]
        [InlineData(DirectionEnum.N, DirectionEnum.E)]
        [InlineData(DirectionEnum.E, DirectionEnum.S)]
        [InlineData(DirectionEnum.S, DirectionEnum.W)]
        public void TurnRight(DirectionEnum current, DirectionEnum expected)
        {
            Rover rover = new Rover(new Coordinate(2, 3), current);
            rover.TurnRight();
            Assert.True(rover.Direction == expected);
        }

        [Theory]
        [InlineData(2, 3, 5, 5, DirectionEnum.W, 1, 3)]
        [InlineData(2, 3, 5, 5, DirectionEnum.E, 3, 3)]
        [InlineData(2, 3, 5, 5, DirectionEnum.S, 2, 2)]
        [InlineData(2, 3, 5, 5, DirectionEnum.N, 2, 4)]
        public void ChangeCoordinate(int roverX, int roverY, int plateauX, int plateauY, DirectionEnum current, int expectedX, int expectedY)
        {
            Rover rover = new Rover(new Coordinate(roverX, roverY), current);
            Plateau plateau = new Plateau(new Coordinate(plateauX, plateauY));
            rover.ChangeCoordinate(plateau);
            Assert.True(rover.Coordinate.X == expectedX && rover.Coordinate.Y == expectedY);
        }
        [Theory]
        [InlineData(5, 5, 5, 5, DirectionEnum.W, true)]
        [InlineData(5, 5, 5, 5, DirectionEnum.S, true)]
        [InlineData(5, 5, 5, 5, DirectionEnum.N, false)]
        [InlineData(5, 5, 5, 5, DirectionEnum.E, false)]
        public void AreaMoveable(int roverX, int roverY, int plateauX, int plateauY, DirectionEnum current, bool expected)
        {
            Rover rover = new Rover(new Coordinate(roverX, roverY), current);
            Plateau plateau = new Plateau(new Coordinate(plateauX, plateauY));
            Assert.True(plateau.Moveable(rover) == expected);
        }
        [Theory]
        [InlineData(1, 2, 5, 5, DirectionEnum.N, "LMLMLMLMM", 1,3, DirectionEnum.N)]
        [InlineData(3, 3, 5, 5, DirectionEnum.E, "MMRMMRMRRM", 5, 1, DirectionEnum.E)]
        public void Explore(int roverX, int roverY, int plateauX, int plateauY, DirectionEnum current, string parameters, int expectedX, int expectedY, DirectionEnum expectedDirection)
        {
            Plateau plateau = new Plateau(new Coordinate(plateauX, plateauY));
            Rover rover = new Rover(new Coordinate(roverX, roverY), current);
            rover.Explore(plateau, parameters);
            Assert.True(rover.Direction == expectedDirection && rover.Coordinate.X == expectedX && rover.Coordinate.Y == expectedY);
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
            rover.Explore(plateau, "LMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRMLMLMLMLMRMRMRMRM");
            Assert.True(rover.Direction == DirectionEnum.N && rover.Coordinate.X == 1 && rover.Coordinate.Y == 2);
        }
    }
}

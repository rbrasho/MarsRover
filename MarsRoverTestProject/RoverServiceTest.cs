using MarsRover.Application;
using MarsRover.Common;
using MarsRover.Exceptions;
using MarsRover.Model;
using System;
using System.Collections.Generic;
using Xunit;

namespace MarsRoverTestProject
{
    public class RoverServiceTest
    {
        [Fact]
        public void Run()
        {
            List<Rover> result = RoverService.Run("5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM");
            List<Rover> expectedList = new List<Rover>();
            expectedList.Add(new Rover(new Coordinate(1, 3), DirectionEnum.N));
            expectedList.Add(new Rover(new Coordinate(5, 1), DirectionEnum.E));
            Assert.True(result[0].ToStringCoordinateAndDirection() == expectedList[0].ToStringCoordinateAndDirection() && result[1].ToStringCoordinateAndDirection() == expectedList[1].ToStringCoordinateAndDirection(), "Wrong Result");
        }
        [Fact]
        public void RunEmptyStringList()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => RoverService.Run("", "", "", "", ""));
            Assert.Equal(new ArgumentNullException().Message, exception.Message);
        }
        [Fact]
        public void InvalidParameter()
        {
            var exception = Assert.Throws<WrongParameterException>(() => RoverService.Run("5 5", "1 2", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM"));
            Assert.Equal(Constants.WarningCorrectData, exception.Message);
        }
        [Fact]
        public void NonNumericParameter()
        {
            var exception = Assert.Throws<NonNumericValueException>(() => RoverService.Run("5 A", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM"));
            Assert.Equal(Constants.WarningNumericValue, exception.Message);
        }

        [Fact]
        public void InvalidDirectionParameter()
        {
            var exception = Assert.Throws<WrongParameterException>(() => RoverService.Run("5 5", "1 2 A", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM"));
            Assert.Equal(Constants.WarningDirectionParameter, exception.Message);
        }
        [Fact]
        public void SpaceError()
        {
            var exception = Assert.Throws<WrongParameterException>(() => RoverService.Run("5 5", "1 2 N", "MMM MMMMM", "3 3 E", "MMRMMRMRRM"));
            Assert.Equal(Constants.WarningWrongParameterString, exception.Message);
        }
        [Fact]
        public void InvalidMove()
        {
            var exception = Assert.Throws<WrongMoveException>(() => RoverService.Run("5 5", "1 2 N", "MMMMMMMM", "3 3 E", "MMRMMRMRRM"));
            Assert.Equal(Constants.WarningMoveString, exception.Message);
        }
    }
}

using MarsRover.Application;
using MarsRover.Common;
using MarsRover.Model;
using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test Input: 
            //5 5
            //1 2 N
            //LMLMLMLMM
            //3 3 E
            //MMRMMRMRRM
            //Expected Output: 
            //1 3 N
            //5 1 E

            Plateau plateau = new Plateau(new Coordinate(5,5));
            Rover roverOne = new Rover(new Coordinate(1,2), Enum.Parse<DirectionEnum>("N"));
            Rover roverTwo = new Rover(new Coordinate(3,3), Enum.Parse<DirectionEnum>("E"));
            roverOne.Explore(plateau, "LMLMLMLMM");
            roverTwo.Explore(plateau, "MMRMMRMRRM");

        }
    }
}

using MarsRover.Application;
using MarsRover.Common;
using MarsRover.Model;
using System;
using System.Collections.Generic;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            //Plateau plateau = new Plateau(new Coordinate(5, 5));
            //Rover roverOne = new Rover(new Coordinate(1, 2), Enum.Parse<DirectionEnum>("N"));
            //Rover roverTwo = new Rover(new Coordinate(3, 3), Enum.Parse<DirectionEnum>("E"));
            //roverOne.Explore(plateau, "LMLMLMLMM");
            //roverTwo.Explore(plateau, "MMRMMRMRRM");

            string firstLine = Console.ReadLine();
            string secondLine = Console.ReadLine();
            string thirdLine = Console.ReadLine();
            string fourthLine = Console.ReadLine();
            string fifthLine = Console.ReadLine();

            foreach (var item in StringWorker.Run(firstLine, secondLine, thirdLine, fourthLine,fifthLine))
            {
                Console.WriteLine(item.ToStringCoordinateAndDirection());
            } 
        }
    }
}

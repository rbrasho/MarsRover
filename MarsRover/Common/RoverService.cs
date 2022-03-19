using MarsRover.Application;
using MarsRover.Exceptions;
using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Common
{
    public class RoverService
    {
        public static List<Rover> Run(String firstLine, String secondLine, String thirdLine, String fourthLine, String fifthLine)
        {
            if (String.IsNullOrEmpty(firstLine) || String.IsNullOrEmpty(secondLine) || String.IsNullOrEmpty(thirdLine) || String.IsNullOrEmpty(fourthLine) || String.IsNullOrEmpty(fifthLine))
            {
                throw new ArgumentNullException();
            }
            List<Rover> roverList = new List<Rover>(); 
            Plateau plateau = CheckAndCreatePlateau(firstLine);
            Rover roverOne = CheckAndCreateRover(secondLine);
            Rover roverTwo = CheckAndCreateRover(fourthLine);

            roverOne.Explore(plateau, thirdLine);
            roverTwo.Explore(plateau, fifthLine);

            roverList.Add(roverOne);
            roverList.Add(roverTwo);
            return roverList;
        }

        private static Rover CheckAndCreateRover(string line)
        {
            string[] lineStringList = line.Split(" ");
            if (lineStringList.Length != 3)
            {
                throw new WrongParameterException(Constants.WarningCorrectData);
            }
            int roverX;
            int roverY;
            bool roverXBool = Int32.TryParse(lineStringList[0], out roverX);
            bool roverYBool = Int32.TryParse(lineStringList[1], out roverY);
            if (!roverXBool || !roverYBool)
            {
                throw new NonNumericValueException(Constants.WarningNumericValue);
            }
            DirectionEnum roverDirection;
            bool isEnum=Enum.TryParse(lineStringList[2], out roverDirection);
            if (!isEnum)
            {
                throw new WrongParameterException(Constants.WarningDirectionParameter);
            }

            return new Rover(new Coordinate(roverX,roverY),roverDirection);
        }

        private static Plateau CheckAndCreatePlateau(string line)
        {
            string[] lineStringList = line.Split(" ");
            if (lineStringList.Length != 2)
            {
                throw new WrongParameterException(Constants.WarningCorrectData);
            }
            int plateauX;
            int plateauY;
            bool plateauXBool = Int32.TryParse(lineStringList[0], out plateauX);
            bool plateauYBool = Int32.TryParse(lineStringList[1], out plateauY);
            if (!plateauXBool || !plateauYBool)
            {
                throw new NonNumericValueException(Constants.WarningNumericValue);
            }
            return new Plateau(new Coordinate(plateauX, plateauY));
        }
    }
}

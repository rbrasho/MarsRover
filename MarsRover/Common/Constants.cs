using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Common
{
    public static class Constants
    {
        public static char Move = 'M';
        public static char Left = 'L';
        public static char Right = 'R';
        public static char North = 'N';
        public static char East = 'E';
        public static char West = 'W';
        public static char South = 'S';
        public static string WarningWrongParameterString = "Please enter L(Left),R(Right) or M(Move)";
        public static string WarningMoveString  = "You shall not pass!!!";
        public static string WarningCorrectData = "Please enter correct data!";
        public static string WarningNumericValue = "Please enter numeric value!";
        public static string WarningDirectionParameter= "Please enter valid enum data (N,S,W,E) for rover!";
    }
}

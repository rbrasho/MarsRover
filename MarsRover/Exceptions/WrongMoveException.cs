using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Exceptions
{
    public class WrongMoveException : Exception
    {
        public WrongMoveException()
        {

        }
        public WrongMoveException(string message)
    : base(message)
        {
        }

        public WrongMoveException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
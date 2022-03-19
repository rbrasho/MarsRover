using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Exceptions
{
    public class WrongParameterException: Exception
    {
        public WrongParameterException()
        {

        }
        public WrongParameterException(string message)
    : base(message)
        {
        }

        public WrongParameterException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
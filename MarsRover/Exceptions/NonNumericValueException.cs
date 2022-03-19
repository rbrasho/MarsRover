using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Exceptions
{
    public class NonNumericValueException : Exception
    {
        public NonNumericValueException()
        {

        }
        public NonNumericValueException(string message)
    : base(message)
        {
        }

        public NonNumericValueException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Abstractions
{
    public interface IArea:IMoveable
    {
        public ICoordinate UpperRightCoordinate { get; set; }
        public ICoordinate LowerLeftCoordinate { get; set; }
    }
}

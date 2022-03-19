using MarsRover.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Abstractions
{
    public interface IVehicle
    {
        public ICoordinate Coordinate { get; set; }
        public DirectionEnum Direction { get; set; }
    }
}

using MarsRover.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Abstractions
{
    public interface IMoveable
    {
        public bool Moveable(IVehicle vehicle);
    }
}

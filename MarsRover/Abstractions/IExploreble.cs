using MarsRover.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Abstractions
{
    public interface IExploreble
    {
        public void Explore(IArea area, String directionString);
        public void ChangeCoordinate(IArea area);
        public bool IsLeft(char item);
        public bool IsRight(char item);
        public void TurnRight();
        public void TurnLeft();

    }
}

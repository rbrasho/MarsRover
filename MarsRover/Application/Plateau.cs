using MarsRover.Abstractions;
using MarsRover.Common;
using MarsRover.Model;

namespace MarsRover.Application
{
    public class Plateau :IArea
    {
        public ICoordinate UpperRightCoordinate { get; set; }
        public ICoordinate LowerLeftCoordinate { get; set; }
        public Plateau(Coordinate coordinate)
        {
            this.UpperRightCoordinate = coordinate;
            this.LowerLeftCoordinate = new Coordinate(0, 0);
        }

        public bool Moveable(IVehicle vehicle)
        {
            switch (vehicle.Direction)
            {
                case DirectionEnum.N:
                    if (vehicle.Coordinate.Y + 1 > this.UpperRightCoordinate.Y) return false;
                    break;
                case DirectionEnum.E:
                    if (vehicle.Coordinate.X + 1 > this.UpperRightCoordinate.X) return false;
                    break;
                case DirectionEnum.S:
                    if (vehicle.Coordinate.Y - 1 < this.LowerLeftCoordinate.Y) return false;
                    break;
                case DirectionEnum.W:
                    if (vehicle.Coordinate.X - 1 < this.LowerLeftCoordinate.X) return false;
                    break;
                default:
                    break;
            }
            return true;
        }
    }
}

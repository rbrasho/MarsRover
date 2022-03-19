using MarsRover.Abstractions;
using MarsRover.Common;
using MarsRover.Exceptions;
using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Application
{
    public class Rover : IVehicle, IExploreble
    {
        public ICoordinate Coordinate { get; set; }
        public DirectionEnum Direction { get; set; }
        public Rover(Coordinate coordinate, DirectionEnum direction)
        {
            this.Coordinate = coordinate;
            this.Direction = direction;
        }

        public void Explore(IArea area, string directionString)
        {
            if (String.IsNullOrEmpty(directionString) )
            {
                throw new ArgumentNullException();
            }

            foreach (var item in directionString)
            {
                if (this.IsLeft(item))
                {
                    this.TurnLeft();
                }
                else if (this.IsRight(item))
                {
                    this.TurnRight();
                }
                else if (this.IsMove(item))
                {
                    this.ChangeCoordinate(area);
                }
                else
                {
                    throw new WrongParameterException(Constants.WarningWrongParameterString);
                }
            }
        }

        public bool IsLeft(char item)
        {
            return (item == Constants.Left);
        }
        public bool IsRight(char item)
        {
            return (item == Constants.Right);
        }
        public bool IsMove(char item)
        {
            return (item == Constants.Move);
        }

        public void ChangeCoordinate(IArea area)
        {
            if (!area.Moveable(this))
            {
                throw new WrongMoveException(Constants.WarningMoveString);
            }

            switch (this.Direction)
            {
                case DirectionEnum.N:
                    this.Coordinate.Y = this.Coordinate.Y + 1;
                    break;
                case DirectionEnum.E:
                    this.Coordinate.X = this.Coordinate.X + 1;
                    break;
                case DirectionEnum.S:
                    this.Coordinate.Y = this.Coordinate.Y - 1;
                    break;
                case DirectionEnum.W:
                    this.Coordinate.X = this.Coordinate.X - 1;
                    break;
                default:
                    break;
            }
        }
        public void TurnLeft()
        {
            int directionValue = (int)(this.Direction - 1);
            this.Direction = (DirectionEnum)(directionValue < 0 ? 3 : directionValue);
        }
        public void TurnRight()
        {
            int directionValue = (int)(this.Direction + 1);
            this.Direction = (DirectionEnum)(directionValue > 3 ? 0 : directionValue);
        }

        public string ToStringCoordinateAndDirection()
        {
            return String.Format("{0} {1} {2}", this.Coordinate.X, this.Coordinate.Y, this.Direction); 
        }
    }
}

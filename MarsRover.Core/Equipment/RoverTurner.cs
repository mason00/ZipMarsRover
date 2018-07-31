using MarsRover.Core.Exceptions;

namespace MarsRover.Core
{
    public class RoverTurner
    {
        public void TurnLeft(Location currentPosition)
        {
            switch (currentPosition.RoverFacing)
            {
                case Facing.E:
                    currentPosition.RoverFacing = Facing.N;
                    break;
                case Facing.S:
                    currentPosition.RoverFacing = Facing.E;
                    break;
                case Facing.W:
                    currentPosition.RoverFacing = Facing.S;
                    break;
                case Facing.N:
                    currentPosition.RoverFacing = Facing.W;
                    break;
                default:
                    throw new TurnException("Unknow facing");
            }
        }

        public void TurnRight(Location currentPosition)
        {
            switch (currentPosition.RoverFacing)
            {
                case Facing.E:
                    currentPosition.RoverFacing = Facing.S;
                    break;
                case Facing.S:
                    currentPosition.RoverFacing = Facing.W;
                    break;
                case Facing.W:
                    currentPosition.RoverFacing = Facing.N;
                    break;
                case Facing.N:
                    currentPosition.RoverFacing = Facing.E;
                    break;
                default:
                    throw new TurnException("Unknow facing");
            }
        }
    }
}
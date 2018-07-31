using MarsRover.Core.Exceptions;

namespace MarsRover.Core
{
    public class RoverMover
    {
        public Position Move(Location currentPosition, Plateau map)
        {
            Position newPosition = null;
            switch (currentPosition.RoverFacing)
            {
                case Facing.E:
                    newPosition = MoveEast(currentPosition.RoverCardinal);
                    break;
                case Facing.S:
                    newPosition = MoveSouth(currentPosition.RoverCardinal);
                    break;
                case Facing.W:
                    newPosition = MoveWest(currentPosition.RoverCardinal);
                    break;
                case Facing.N:
                    newPosition = MoveNorth(currentPosition.RoverCardinal);
                    break;
                default:
                    throw new MoveException("Unknow facing to move");
            }
            if (ValidPositionOnPlateau(newPosition, map))
                return newPosition;
            else
                throw new MoveException("Moving out of plateau");
        }

        private bool ValidPositionOnPlateau(Position newPosition, Plateau map)
        {
            return newPosition.X >=0 && newPosition.X <= map.BoundaryX && newPosition.Y >= 0 && newPosition.Y <= map.BoundaryY;
        }

        private Position MoveEast(Position roverCardinal)
        {
            return new Position(roverCardinal.X + 1, roverCardinal.Y);
        }

        private Position MoveSouth(Position roverCardinal)
        {
            return new Position(roverCardinal.X, roverCardinal.Y - 1);
        }

        private Position MoveWest(Position roverCardinal)
        {
            return new Position(roverCardinal.X - 1,  roverCardinal.Y);
        }

        private Position MoveNorth(Position roverCardinal)
        {
            return new Position(roverCardinal.X,  roverCardinal.Y + 1);
        }
    }
}
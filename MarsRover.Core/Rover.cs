using System;

namespace MarsRover.Core
{
    public class Rover
    {
        private readonly Plateau map;
        private readonly Location currentLocation;
        private readonly string roverCommand;

        private readonly RoverTurner turner = new RoverTurner();
        private readonly RoverMover mover = new RoverMover();
        
        public Rover(Plateau plateau, Location position, string command)
        {
            map = plateau;
            currentLocation = position;
            roverCommand = command;
        }

        public string LocationInfo => $"{currentLocation.RoverCardinal.X} {currentLocation.RoverCardinal.Y} {currentLocation.RoverFacing}";

        public void RunCommand()
        {
            foreach (var cmd in roverCommand)
            {
                switch (cmd)
                {
                    case 'L':
                        turner.TurnLeft(currentLocation);
                        break;
                    case 'R':
                        turner.TurnRight(currentLocation);
                        break;
                    case 'M':
                        currentLocation.RoverCardinal = mover.Move(currentLocation, map);
                        break;
                    default:
                        throw new Exception("Unknown rover command");
                }
            }
        }
    }
}

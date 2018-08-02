using System;

namespace MarsRover.Core
{
    public class InputReader
    {
        public Plateau ReadPlateauBoundary(string plateauInput)
        {
            if (!string.IsNullOrWhiteSpace(plateauInput))
            {
                var parts = plateauInput.Trim().Split(' ');
                if (parts.Length == 2)
                {
                    var position = ParsePosition(parts[0], parts[1]);
                    if (position != null)
                        return new Plateau(position.X, position.Y);
                }
            }

            throw new UserInputException("Cannot read plateau size");
        }

        public Location ReadRoverLocation(string roverPositionInput)
        {
            if (!string.IsNullOrWhiteSpace(roverPositionInput))
            {
                var parts = roverPositionInput.Trim().Split(' ');
                if (parts.Length == 3)
                {
                    var position = ParsePosition(parts[0], parts[1]);
                    var facing = ParseFacing(parts[2]);
                    if (position != null)
                        return new Location(position, facing);
                }
            }

            throw new UserInputException("Cannot read rover position");
        }

        public string ReadRoverCommand(string roverCommandInput)
        {
            if (!string.IsNullOrWhiteSpace(roverCommandInput))
            {
                var command = roverCommandInput.Trim();
                foreach(var c in command)
                {
                    switch (c)
                    {
                        case 'L':
                        case 'R':
                        case 'M':
                            continue;
                        default:
                            throw new UserInputException("Invalid command");
                    }
                }

                return command;
            }

            throw new UserInputException("Command cannot be empty");
        }

        private Position ParsePosition(string m, string n)
        {
            if (int.TryParse(m, out int x) && int.TryParse(n, out int y))
            {
                return new Position(x, y);
            }
            return null;
        }

        private Facing ParseFacing(string v)
        {
            if (Enum.TryParse(v, out Facing result))
                return result;
            throw new UserInputException("Cannot read facing");
        }

    }
}

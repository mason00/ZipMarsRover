using System;
using System.Collections.Generic;
using MarsRover.Core;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mars Rover Challenge");

            var reader = new InputReader();

            var plateauInput = Console.ReadLine();
            Plateau plateauArea = null;

            try
            {
                plateauArea = reader.ReadPlateauBoundary(plateauInput);
            }
            catch (UserInputException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            
            var rovers = new List<Rover>();
            var newRoverPositionInput = string.Empty;
            do
            {
                try
                {
                    DeployRover(newRoverPositionInput, reader, plateauArea, rovers);
                }
                catch (UserInputException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                
                newRoverPositionInput = Console.ReadLine().Trim();
            } while (newRoverPositionInput.Length > 0);

            MoveRovers(rovers);
        }

        private static void MoveRovers(List<Rover> rovers)
        {
            foreach (var rover in rovers)
            {
                rover.RunCommand();
                Console.WriteLine(rover.LocationInfo);
            }
        }

        private static void DeployRover(string input, InputReader reader, Plateau plateau, List<Rover> rovers)
        {
            var roverInput = string.IsNullOrWhiteSpace(input) ? Console.ReadLine().Trim() : input;
            var roverLocation = reader.ReadRoverLocation(roverInput);

            var commandInput = Console.ReadLine();
            var roverCommand = reader.ReadRoverCommand(commandInput);

            var rover = new Rover(plateau, roverLocation, roverCommand);
            rovers.Add(rover);
        }
    }
}

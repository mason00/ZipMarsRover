using MarsRover.Core;
using MarsRover.Core.Exceptions;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverTests
    {
        [Theory]
        [InlineData(5, 5, 1, 2, Facing.N, "LMLMLMLMM", "1 3 N")]
        [InlineData(5, 5, 3, 3, Facing.E, "MMRMMRMRRM", "5 1 E")]
        [InlineData(10, 10, 2, 3, Facing.W, "LMMRLLMM", "4 1 E")]
        [InlineData(25, 40, 5, 4, Facing.N, "MMMRMLLMM", "4 7 W")]
        [InlineData(45, 15, 5, 1, Facing.S, "LMRRMLLLRM", "6 1 E")]
        public void RunCommand_Should_Set_Rover_Location(double plateauX, double plateauY, double positionX, double positionY, Facing facing, string cmd, string info)
        {
            var plateau = new Plateau(plateauX, plateauY);
            var currentLocation = new Location(new Position(positionX, positionY), facing);

            var rover = new Rover(plateau, currentLocation, cmd);

            rover.RunCommand();

            Assert.Equal(info, rover.LocationInfo);
        }

        [Theory]
        [InlineData(5, 5, 1, 2, Facing.N, "MMMMMMMMM", "1 5 N")]
        [InlineData(5, 5, 3, 3, Facing.E, "MMMMMMMMMM", "5 3 E")]
        public void RunCommand_Should_Set_ErrorInfo(double plateauX, double plateauY, double positionX, double positionY, Facing facing, string cmd, string info)
        {
            var plateau = new Plateau(plateauX, plateauY);
            var currentLocation = new Location(new Position(positionX, positionY), facing);

            var rover = new Rover(plateau, currentLocation, cmd);

            Assert.Throws<MoveException>(() => rover.RunCommand());
        }
    }
}

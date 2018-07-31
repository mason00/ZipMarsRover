using MarsRover.Core;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverTurnerTests
    {
        [Theory]
        [InlineData(0, 0, Facing.E, 0, 0, Facing.N)]
        [InlineData(2, 3, Facing.W, 2, 3, Facing.S)]
        [InlineData(5, 4, Facing.N, 5, 4, Facing.W)]
        [InlineData(5, 1, Facing.S, 5, 1, Facing.E)]
        public void TurnLeft_Should_Turn(double x, double y, Facing facing, double targetX, double targetY, Facing targetFacing)
        {
            var currentLocation = new Location(new Position(x, y), facing);
            var turner = new RoverTurner();

            turner.TurnLeft(currentLocation);

            Assert.Equal(targetFacing, currentLocation.RoverFacing);
            Assert.Equal(targetX, currentLocation.RoverCardinal.X);
            Assert.Equal(targetY, currentLocation.RoverCardinal.Y);
        }

        [Theory]
        [InlineData(0, 0, Facing.E, 0, 0, Facing.S)]
        [InlineData(2, 3, Facing.W, 2, 3, Facing.N)]
        [InlineData(5, 4, Facing.N, 5, 4, Facing.E)]
        [InlineData(5, 1, Facing.S, 5, 1, Facing.W)]
        public void TurnRight_Should_Turn(double x, double y, Facing facing, double targetX, double targetY, Facing targetFacing)
        {
            var currentLocation = new Location(new Position(x, y), facing);
            var turner = new RoverTurner();

            turner.TurnRight(currentLocation);

            Assert.Equal(targetFacing, currentLocation.RoverFacing);
            Assert.Equal(targetX, currentLocation.RoverCardinal.X);
            Assert.Equal(targetY, currentLocation.RoverCardinal.Y);
        }
    }
}

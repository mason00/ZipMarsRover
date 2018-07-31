using MarsRover.Core;
using MarsRover.Core.Exceptions;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverMoverTests
    {
        [Theory]
        [InlineData(0, 0, Facing.E, 1, 0)]
        [InlineData(2, 3, Facing.W, 1, 3)]
        [InlineData(5, 4, Facing.N, 5, 5)]
        [InlineData(5, 1, Facing.S, 5, 0)]
        public void Move_Should_Move_Position(double x, double y, Facing facing, double targetX, double targetY)
        {
            var currentLocation = new Location(new Position(x, y), facing);
            var plateau = new Plateau(5, 5);
            
            var mover = new RoverMover();

            var targetPosition = mover.Move(currentLocation, plateau);

            Assert.Equal(targetX, targetPosition.X);
            Assert.Equal(targetY, targetPosition.Y);
        }

        [Theory]
        [InlineData(5, 0, Facing.E)]
        [InlineData(0, 3, Facing.W)]
        [InlineData(1, 5, Facing.N)]
        [InlineData(4, 0, Facing.S)]
        public void Move_Should_Throw_If_Outbounded(double x, double y, Facing facing)
        {
            var currentLocation = new Location(new Position(x, y), facing);
            var plateau = new Plateau(5, 5);
            
            var mover = new RoverMover();

            Assert.Throws<MoveException>(() => mover.Move(currentLocation, plateau));
        }
    }
}

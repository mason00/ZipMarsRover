using MarsRover.Core;
using Xunit;

namespace MarsRover.Tests
{
    public class UIReaderTests
    {
        [Theory]
        [InlineData("5 5", 5, 5)]
        [InlineData("10 15", 10, 15)]
        public void ReadPlateauSize_Should_Read_Correct_Size(string input, double x, double y)
        {
            var reader = new InputReader();
            Plateau plateauPosition = null;
            plateauPosition = reader.ReadPlateauBoundary(input);
            Assert.Equal(x, plateauPosition.BoundaryX);
            Assert.Equal(y, plateauPosition.BoundaryY);
        }

        [Theory]
        [InlineData("10.7 15", 10, 15)]
        [InlineData("55", 5, 5)]
        [InlineData("x5", 5, 5)]
        public void ReadPlateauSize_Should_Throw_For_InValid_Size(string input, double x, double y)
        {
            var reader = new InputReader();
            Plateau plateauPosition = null;
            Assert.Throws<UserInputException>(() => plateauPosition = reader.ReadPlateauBoundary(input));
        }

        [Theory]
        [InlineData("1 2 N", 1, 2, Facing.N)]
        [InlineData("12 32 E", 12, 32, Facing.E)]
        [InlineData("5 79 W", 5, 79, Facing.W)]
        [InlineData("891 45 S", 891, 45, Facing.S)]
        public void ReadRoverLocation_Should_Read_Location(string input, double x, double y, Facing facing)
        {
            var reader = new InputReader();
            var result = reader.ReadRoverLocation(input);

            Assert.Equal(x, result.RoverCardinal.X);
            Assert.Equal(y, result.RoverCardinal.Y);
            Assert.Equal(facing, result.RoverFacing);
        }

        [Theory]
        [InlineData("1 2N")]
        [InlineData("12 32")]
        [InlineData("W")]
        [InlineData("891 45.65 S")]
        public void ReadRoverLocation_Should_Throw_For_InValid_Location(string input)
        {
            var reader = new InputReader();
            Assert.Throws<UserInputException>(() => reader.ReadRoverLocation(input));
        }

        [Theory]
        [InlineData("LMLMLMMMM")]
        [InlineData("LRMRLMMLR")]
        public void ReadRoverCommand_Should_Read_Command(string input)
        {
            var reader = new InputReader();
            var result = reader.ReadRoverCommand(input);
            Assert.Equal(input, result);
        }

        [Theory]
        [InlineData("LMLMLM MMM")]
        [InlineData("LRMRLMXLR")]
        public void ReadRoverCommand_Should_Throw_For_InValid_Command(string input)
        {
            var reader = new InputReader();
            Assert.Throws<UserInputException>(() => reader.ReadRoverCommand(input));
        }
    }
}

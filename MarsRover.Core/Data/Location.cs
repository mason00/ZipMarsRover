namespace MarsRover.Core
{
    public class Location
    {
        public Location(Position position, Facing facing)
        {
            RoverCardinal = position;
            RoverFacing = facing;
        }
        public Location(double x, double y, Facing facing)
        {
            RoverCardinal = new Position(x, y);
            RoverFacing = facing;
        }
        public Position RoverCardinal { get; set; }
        public Facing RoverFacing { get; set; }
    }
}
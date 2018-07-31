namespace MarsRover.Core
{
    public class Plateau
    {
        public Plateau(double x, double y)
        {
            BoundaryX = x;
            BoundaryY = y;
        }
        public double BoundaryX { get; }
        public double BoundaryY { get; }
    }
}
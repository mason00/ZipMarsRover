using System;

namespace MarsRover.Core.Exceptions
{
    public class MoveException : Exception
    {
        public MoveException(string message) : base(message) {}
    }
}

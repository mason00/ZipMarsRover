using System;

namespace MarsRover.Core.Exceptions
{
    public class TurnException : Exception
    {
        public TurnException(string message) : base(message) {}
    }
}

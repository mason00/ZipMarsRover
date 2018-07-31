using System;

namespace MarsRover.Core
{
    public class UserInputException : Exception
    {
        public UserInputException(string message) : base(message) {}
    }
}

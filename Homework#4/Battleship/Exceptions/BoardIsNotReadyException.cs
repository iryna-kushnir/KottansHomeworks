using System;

namespace Battleship.Exceptions
{
    public class BoardIsNotReadyException : Exception
    {
        public BoardIsNotReadyException(string message)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}
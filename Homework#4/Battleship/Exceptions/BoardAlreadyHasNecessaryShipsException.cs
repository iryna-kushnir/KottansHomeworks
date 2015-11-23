using System;

namespace Battleship.Exceptions
{
    public class BoardAlreadyHasNecessaryShipsException : Exception
    {
        public BoardAlreadyHasNecessaryShipsException(string message)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}
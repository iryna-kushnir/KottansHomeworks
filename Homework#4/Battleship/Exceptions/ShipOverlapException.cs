using System;

namespace Battleship.Exceptions
{
    public class ShipOverlapException : Exception
    {
        public ShipOverlapException(string message)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}
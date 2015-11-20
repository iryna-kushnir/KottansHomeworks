using System;

namespace Battleship
{
    public class NotAShipException : Exception
    {
    }

    public class ShipOverlapException : Exception
    {
        public ShipOverlapException(string message)
        {
            Message = message;
        }

        public override string Message { get; }
    }

    public class BoardIsNotReadyException : Exception
    {
        public BoardIsNotReadyException(string message)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}
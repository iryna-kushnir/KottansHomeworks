using System;
using System.Text.RegularExpressions;

namespace Battleship
{
    public abstract class Ship
    {
        public Ship(uint x, uint y)
        {
            Direction = Direction.Horizontal;
            X = x;
            Y = y;
        }

        public Ship(uint x, uint y, Direction direction = Direction.Horizontal) : this(x, y)
        {
            Direction = direction;
        }

        public uint X { get; }
        public uint Y { get; }
        public Direction Direction { get; }

        public abstract uint Length { get; }

        protected bool Equals(Ship other)
        {
            return X == other.X && Y == other.Y && Direction == other.Direction;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Ship) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) X;
                hashCode = (int) ((hashCode*397) ^ Y);
                hashCode = (hashCode*397) ^ (int) Direction;
                return hashCode;
            }
        }

        public static Ship Parse(string notation)
        {
            var regex = new Regex(@"^([A-J]([1-9]|10))(x[1-4]([-,|])?)?$");
            if (!regex.IsMatch(notation)) throw new NotAShipException();
            var indexOfX = notation.IndexOf("x");
            var x = (uint) (notation[0] - 64);
            var y = uint.Parse(notation.Substring(1, indexOfX == -1 ? notation.Length - 1 : indexOfX - 1));
            var direction = Direction.Horizontal;
            if (notation.Contains("|")) direction = Direction.Vertical;
            var decks = indexOfX == -1 ? 1 : int.Parse(notation.Substring(indexOfX + 1, 1));
            switch (decks)
            {
                case 1:
                    return new PatrolBoat(x, y);
                case 2:
                    return new Cruiser(x, y, direction);
                case 3:
                    return new Submarine(x, y, direction);
                case 4:
                    return new AircraftCarrier(x, y, direction);
                default:
                    return new PatrolBoat(x, y);
                    ;
            }
        }

        public static bool TryParse(string notation, out Ship ship)
        {
            try
            {
                ship = Parse(notation);
                return true;
            }
            catch (NotAShipException)
            {
                ship = null;
                return false;
            }
        }

        public bool FitsInSquare(byte squareHeight, byte squareWidth)
        {
            return (X + (Direction == Direction.Horizontal ? Length - 1 : 0) <= squareWidth) &&
                   (Y + (Direction == Direction.Vertical ? Length - 1 : 0) <= squareHeight);
        }

        public bool OverlapsWith(Ship otherShip)
        {
            return
                (Math.Abs(
                    (int)
                        (X + (Direction == Direction.Horizontal ? Length - 1 : 0) - otherShip.X -
                         (otherShip.Direction == Direction.Horizontal ? otherShip.Length - 1 : 0))) <= 1) &&
                (Math.Abs(
                    (int)
                        (Y + (Direction == Direction.Vertical ? Length - 1 : 0) - otherShip.Y -
                         (otherShip.Direction == Direction.Vertical ? otherShip.Length - 1 : 0))) <= 1);
        }


        public override string ToString()
        {
            return $"{(char) X + 64}{Y}x{Length}" + (Direction == Direction.Horizontal ? "-" : "|");
        }
    }
}
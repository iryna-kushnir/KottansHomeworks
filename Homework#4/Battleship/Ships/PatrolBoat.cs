namespace Battleship.Ships
{
    public class PatrolBoat : Ship
    {
        public PatrolBoat(uint x, uint y) : base(x, y)
        {
        }

        public PatrolBoat(uint x, uint y, Direction direction) : base(x, y, direction)
        {
        }

        public override uint Length => 1u;

        protected bool Equals(PatrolBoat other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((PatrolBoat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (int) ((X*397) ^ Y);
            }
        }
    }
}
namespace Battleship.Ships
{
    public class Submarine : Ship
    {
        public Submarine(uint x, uint y) : base(x, y)
        {
        }

        public Submarine(uint x, uint y, Direction direction) : base(x, y, direction)
        {
        }

        public override uint Length => 3u;
    }
}
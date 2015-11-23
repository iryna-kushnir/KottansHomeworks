namespace Battleship.Ships
{
    public class Cruiser : Ship
    {
        public Cruiser(uint x, uint y) : base(x, y)
        {
        }

        public Cruiser(uint x, uint y, Direction direction) : base(x, y, direction)
        {
        }


        public override uint Length => 2u;
    }
}
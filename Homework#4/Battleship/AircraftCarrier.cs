namespace Battleship
{
    public class AircraftCarrier : Ship
    {
        public AircraftCarrier(uint x, uint y) : base(x, y)
        {
        }

        public AircraftCarrier(uint x, uint y, Direction direction) : base(x, y, direction)
        {
        }

        public override uint Length => 4u;
    }
}
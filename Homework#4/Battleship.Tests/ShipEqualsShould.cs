using Battleship.Ships;
using NUnit.Framework;

namespace Battleship.Tests
{
    public class ShipEqualsShould
    {
        [Test]
        public void ReturnFalse_ComparingDifferentXAndY()
        {
            var ship1 = new PatrolBoat(1, 2);
            var ship2 = new PatrolBoat(2, 2);
            var ship3 = new PatrolBoat(1, 1);

            Assert.AreNotEqual(ship1, ship2);
            Assert.AreNotEqual(ship1, ship3);
        }

        [Test]
        public void ReturnTrue_ComparingWithSameXAndY()
        {
            var ship1 = new PatrolBoat(1, 2);
            var ship2 = new PatrolBoat(1, 2);

            Assert.AreEqual(ship1, ship2);
        }

        [Test]
        public void ReturnFalse_ComparingWithDifferentLength()
        {
            var ship1 = new PatrolBoat(1, 2);
            var ship2 = new Cruiser(1, 2);

            Assert.AreNotEqual(ship1, ship2);
        }

        [Test]
        public void ReturnTrue_ComparingWithSameDirection()
        {
            var ship1 = new PatrolBoat(1, 2, Direction.Vertical);
            var ship2 = new PatrolBoat(1, 2, Direction.Vertical);

            Assert.AreEqual(ship1, ship2);
        }

        [Test]
        public void ReturnTrue_ComparingWithDifferentDirectionsAndLength1()
        {
            var ship1 = new PatrolBoat(1, 2, Direction.Horizontal);
            var ship2 = new PatrolBoat(1, 2, Direction.Vertical);

            Assert.AreEqual(ship1, ship2);
        }

        [Test]
        public void ReturnFalse_ComparingWithDifferentDirectionsAndLengthAbove1()
        {
            var ship1 = new Cruiser(1, 2, Direction.Horizontal);
            var ship2 = new Cruiser(1, 2, Direction.Vertical);

            Assert.AreNotEqual(ship1, ship2);
        }
    }
}
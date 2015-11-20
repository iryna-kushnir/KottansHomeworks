using System;
using System.Collections.Generic;

namespace Battleship
{
    public class Board
    {
        private readonly List<Ship> _ships = new List<Ship>();
        private readonly int _requiredAircraftCarriers = 1;
        private readonly int _requiredCruisers = 3;

        private readonly int _requiredPatrolBoats = 4;
        private readonly int _requiredSubmarines = 2;

        public void Add(Ship ship)
        {
            if (ship.X + (ship.Direction == Direction.Horizontal ? ship.Length - 1 : 0) > 10 ||
                ship.Y + (ship.Direction == Direction.Vertical ? ship.Length - 1 : 0) > 10)
                throw new ArgumentOutOfRangeException();
            foreach (var alreadyAddedShip in _ships)
            {
                if (ship.OverlapsWith(alreadyAddedShip))
                {
                    throw new ShipOverlapException($"Ship {ship} overlaps with {alreadyAddedShip}");
                }
            }
            _ships.Add(ship);
        }

        public void Add(string notation)
        {
            Add(Ship.Parse(notation));
        }

        public List<Ship> GetAll()
        {
            return _ships;
        }

        public void Validate()
        {
            int numberOfPatrolBoats = 0, numberOfCruisers = 0, numberOfSubmarines = 0, numberOfAircraftCarriers = 0;
            foreach (var ship in _ships)
            {
                if (ship.GetType() == typeof (PatrolBoat)) numberOfPatrolBoats ++;
                if (ship.GetType() == typeof (Cruiser)) numberOfCruisers ++;
                if (ship.GetType() == typeof (Submarine)) numberOfSubmarines++;
                if (ship.GetType() == typeof (AircraftCarrier)) numberOfAircraftCarriers++;
            }

            var errorMessage = string.Empty;
            if (numberOfPatrolBoats < _requiredPatrolBoats)
                errorMessage += $"PatrolBoat ({_requiredPatrolBoats - numberOfPatrolBoats})";
            if (numberOfCruisers < _requiredCruisers)
                errorMessage += errorMessage == string.Empty
                    ? string.Empty
                    : ", " + $"Cruiser ({_requiredCruisers - numberOfCruisers})";
            if (numberOfSubmarines < _requiredSubmarines)
                errorMessage += errorMessage == string.Empty
                    ? string.Empty
                    : ", " + $"Submarine ({_requiredSubmarines - numberOfSubmarines})";
            if (numberOfAircraftCarriers < _requiredAircraftCarriers)
                errorMessage += errorMessage == string.Empty
                    ? string.Empty
                    : ", " + $"AircraftCarrier ({_requiredAircraftCarriers - numberOfAircraftCarriers})";
            if (errorMessage != string.Empty)
                throw new BoardIsNotReadyException($"There is not sufficient count of ships. We need: {errorMessage}");
        }
    }
}
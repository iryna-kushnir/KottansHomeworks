using System;
using System.Collections.Generic;
using Battleship.Exceptions;
using Battleship.Ships;

namespace Battleship
{
    public class Board
    {
        private readonly Dictionary<Type, int> _requiredNumbersOfShips = new Dictionary<Type, int>
        {
            [typeof (PatrolBoat)] = 4,
            [typeof (Cruiser)] = 3,
            [typeof (Submarine)] = 2,
            [typeof (AircraftCarrier)] = 1
        };

        private readonly List<Ship> _ships = new List<Ship>();

        public void Add(Ship ship)
        {
            if (!GetDiffInQuantitiesOfRequiredAndActualShips().ContainsKey(ship.GetType()))
                throw new BoardAlreadyHasNecessaryShipsException(
                    $"Board already has all necessary {ship.GetType().Name} ships!");
            if (ship.EndX > 10 ||
                ship.EndY > 10)
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
            var diffsInQuantitiesOfShips = GetDiffInQuantitiesOfRequiredAndActualShips();

            var errorMessage = string.Empty;

            foreach (var ship in diffsInQuantitiesOfShips.Keys)
            {
                errorMessage += errorMessage == string.Empty
                    ? ", "
                    : $"{ship} ({diffsInQuantitiesOfShips[ship]})";
            }
            if (errorMessage != string.Empty)
                throw new BoardIsNotReadyException($"There is not sufficient count of ships. We need: {errorMessage}");
        }

        private Dictionary<Type, int> GetDiffInQuantitiesOfRequiredAndActualShips()
        {
            var actualQuantitiesOfShips = new Dictionary<Type, int>
            {
                [typeof (PatrolBoat)] = 0,
                [typeof (Cruiser)] = 0,
                [typeof (Submarine)] = 0,
                [typeof (AircraftCarrier)] = 0
            };

            foreach (var ship in _ships)
            {
                actualQuantitiesOfShips[ship.GetType()] ++;
            }

            var diffs = new Dictionary<Type, int>();

            foreach (var ship in actualQuantitiesOfShips.Keys)
            {
                var diff = _requiredNumbersOfShips[ship] - actualQuantitiesOfShips[ship];
                if (diff > 0) diffs.Add(ship, diff);
            }

            return diffs;
        }
    }
}
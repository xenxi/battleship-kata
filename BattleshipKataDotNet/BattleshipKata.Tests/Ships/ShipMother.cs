using BattleshipKata.Ships;
using BattleshipKata.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipKata.Tests.Ships
{
    public static class ShipMother
    {
        public static Ship Create(Coordinates coordinates)
        {
            return new Ship(coordinates);
        }

        public static Ship Random()
        {
            return Create(CoordinatesMother.Random());
        }

        public static List<Ship> Randoms(int maxItems = 10)
        {
            return Enumerable
                .Range(0, MotherCreator.Random().Number(min: 1, max: maxItems))
                .Select(_ => Random())
                .ToList();
        }
    }
}
using BattleshipKata.Ships;
using BattleshipKata.Tests.ValueObjects;
using BattleshipKata.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipKata.Tests.Ships
{
    public static class DestroyerMother
    {
        public static Ship Create(Coordinates coordinates, Orientation orientation)
        {
            return new Destroyer(orientation, coordinates);
        }
 
        public static Ship Random(Coordinates coordinates = null, Orientation? orientation = null)
        {
            return Create(coordinates ?? CoordinatesMother.Random(), orientation ?? OrientationMother.Random());
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
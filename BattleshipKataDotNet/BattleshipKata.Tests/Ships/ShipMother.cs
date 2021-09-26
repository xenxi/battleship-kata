using BattleshipKata.Ships;
using BattleshipKata.Tests.Shared;
using BattleshipKata.Tests.ValueObjects;
using BattleshipKata.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipKata.Tests.Ships
{
    public static class ShipMother
    {
        public static Ship Create(Coordinates position, Orientation orientation, ShipType type, int lenght)
            => new ShipFake(orientation: orientation, lenght: lenght, type: type, position: position);

        public static Ship Random(Coordinates position = null, Orientation? orientation = null, int? lenght = null) => Create(
            position: position ?? CoordinatesMother.Random(),
            type: MotherCreator.Random().Enum<ShipType>(),
            lenght: lenght ?? MotherCreator.Random().Number(min: 1, max: 5),
            orientation: orientation ?? OrientationMother.Random());

        public static List<Ship> Randoms(int maxItems = 10) => Enumerable
            .Range(0, MotherCreator.Random().Number(min: 1, max: maxItems))
            .Select(_ => Random())
            .ToList();
    }
}
using BattleshipKata.Ships;
using BattleshipKata.ValueObjects;

namespace BattleshipKata.Tests.Ships
{
    internal class ShipFake : Ship
    {
        internal ShipFake(Orientation orientation, int lenght, BattleshipKata.ValueObjects.Coordinates position) : base(orientation, lenght, position)
        {
        }

        public override ShipType Type => ShipType.Carrier;
    }
}
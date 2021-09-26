using BattleshipKata.Ships;
using BattleshipKata.ValueObjects;

namespace BattleshipKata.Tests.Ships
{
    internal class ShipFake : Ship
    {
        internal ShipFake(Orientation orientation, int lenght, Coordinates position) : base(orientation, lenght, position)
        {
        }

        public ShipStatus State { get; private set; }
        public override ShipType Type => ShipType.Carrier;
    }
}
using BattleshipKata.Ships;
using BattleshipKata.ValueObjects;

namespace BattleshipKata.Tests.Ships
{
    internal class ShipFake : Ship
    {
        internal ShipFake(Orientation orientation, int lenght, Coordinates position, ShipType type) : base(orientation, lenght, position)
        {
            Type = type;
        }
        public override ShipType Type { get; }
    }
}
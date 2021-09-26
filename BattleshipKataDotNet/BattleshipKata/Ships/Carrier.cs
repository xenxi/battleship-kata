using BattleshipKata.ValueObjects;

namespace BattleshipKata.Ships
{
    public class Carrier : Ship
    {
        public Carrier(Orientation orientation, Coordinates position) : base(orientation, 4, position)
        {
        }

        public override ShipType Type => ShipType.Carrier;
    }
}
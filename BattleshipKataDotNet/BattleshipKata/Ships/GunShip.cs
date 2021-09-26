using BattleshipKata.ValueObjects;

namespace BattleshipKata.Ships
{
    public class GunShip : Ship
    {
        public GunShip(Coordinates position) : base(Orientation.Horizontal, 1, position)
        {
        }

        public override ShipType Type => ShipType.GunShip;
    }
}
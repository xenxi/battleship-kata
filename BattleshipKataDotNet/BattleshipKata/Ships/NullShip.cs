using BattleshipKata.ValueObjects;
using System;

namespace BattleshipKata.Ships
{
    public class NullShip : Ship
    {
        public NullShip() : base(Orientation.Horizontal, 0, ValueObjects.Coordinates.Empty())
        {
        }

        public override ShipType Type => ShipType.NullShip;

        public override bool Shot() => false;
    }
}
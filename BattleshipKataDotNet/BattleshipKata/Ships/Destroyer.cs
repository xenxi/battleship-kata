using BattleshipKata.ValueObjects;

namespace BattleshipKata.Ships {
    public class Destroyer : Ship {
        public Destroyer(Orientation orientation, Coordinates position) : base(orientation, 3, position) { }
        public override ShipType Type => ShipType.Destroyer;
    }
}
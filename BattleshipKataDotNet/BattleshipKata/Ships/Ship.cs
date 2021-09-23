using System.Collections.Generic;
using BattleshipKata.ValueObjects;

namespace BattleshipKata.Ships {
    public abstract class Ship {
        public Ship(Orientation orientation, int lenght, Coordinates position) {
            Orientation = orientation;
            Lenght = lenght;
            Position = position;
        }

        public abstract ShipType Type { get; }
        public Orientation Orientation { get; }
        public int Lenght { get; }
        public Coordinates Position { get; }
    }
}
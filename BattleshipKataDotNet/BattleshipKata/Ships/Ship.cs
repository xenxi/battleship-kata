using BattleshipKata.ValueObjects;

namespace BattleshipKata.Ships
{
    public class Ship
    {
        public Ship(Coordinates position)
        {
            Position = position;
        }

        public Coordinates Position { get; }
    }
}
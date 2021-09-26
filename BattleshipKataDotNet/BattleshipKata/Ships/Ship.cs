using BattleshipKata.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipKata.Ships
{
    public abstract class Ship
    {
        protected Ship(Orientation orientation, int lenght, Coordinates position)
        {
            Coordinates = CalculeCoordinates(position, lenght, orientation);
            Lives = Coordinates.Count;
        }

        public IList<Coordinates> Coordinates { get; }
        public int Lives { get; private set; }
        public Coordinates Position => Coordinates.First();

        public abstract ShipType Type { get; }

        public static Ship Empty() => new NullShip();

        public virtual bool Fire() => true;

        private static IList<Coordinates> CalculeCoordinates(Coordinates start, int length, Orientation orientation)
        {
            var coordinates = new List<Coordinates>();
            for (int i = 0; i < length; i++)
            {
                if (orientation == Orientation.Vertical)
                    coordinates.Add(new Coordinates(x: start.X, y: start.Y - i));
                else
                    coordinates.Add(new Coordinates(x: start.X + i, y: start.Y));
            }

            return coordinates;
        }
    }
}
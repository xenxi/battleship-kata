using BattleshipKata.ValueObjects;
using System;
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
            State = ShipStatus.NotTouched;
        }

        public IList<Coordinates> Coordinates { get; }
        public int Lives { get; private set; }
        public Coordinates Position => Coordinates.First();

        public ShipStatus State { get; private set; }
        public abstract ShipType Type { get; }

        public static Ship Empty() => new NullShip();

        public virtual bool Shot()
        {
            Lives--;
            State = Lives > 0 ? ShipStatus.Touched : ShipStatus.Sunken;

            return true;
        }

        private static IList<Coordinates> CalculeCoordinates(Coordinates start, int length, Orientation orientation)
        {
            var coordinates = new List<Coordinates>();
            for (int i = 0; i < length; i++)
            {
                if (orientation == Orientation.Vertical)
                    coordinates.Add(new Coordinates(x: start.X, y: start.Y + i));
                else
                    coordinates.Add(new Coordinates(x: start.X + i, y: start.Y));
            }

            return coordinates;
        }

        public bool IsSunk() => State == ShipStatus.Sunken;
    }
}
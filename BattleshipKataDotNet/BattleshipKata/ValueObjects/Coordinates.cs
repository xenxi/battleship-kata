using System;
using System.Collections.Generic;

namespace BattleshipKata.ValueObjects
{
    public class Coordinates : IEquatable<Coordinates>
    {
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
        public static Coordinates Empty() => new NullCoordinates();

        public override bool Equals(object obj)
        {
            return Equals(obj as Coordinates);
        }

        public bool Equals(Coordinates other)
        {
            return other != null &&
                   EqualityComparer<object>.Default.Equals(X, other.X) &&
                   EqualityComparer<object>.Default.Equals(Y, other.Y);
        }
    }
}
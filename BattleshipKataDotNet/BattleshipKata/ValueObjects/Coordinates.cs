using System;
using System.Collections.Generic;

namespace BattleshipKata.ValueObjects
{
    public class Coordinates : IEquatable<Coordinates>
    {
        private object x;
        private object y;

        public Coordinates(object x, object y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Coordinates);
        }

        public bool Equals(Coordinates other)
        {
            return other != null &&
                   EqualityComparer<object>.Default.Equals(x, other.x) &&
                   EqualityComparer<object>.Default.Equals(y, other.y);
        }
    }
}
using System;

namespace BattleshipKata.ValueObjects {
    public class Coordinates : IEquatable<Coordinates> {
        public Coordinates(int x, int y) {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public bool Equals(Coordinates other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Coordinates)obj);
        }

        public override int GetHashCode() {
            return HashCode.Combine(X, Y);
        }

        public static Coordinates Empty() {
            return new NullCoordinates();
        }

        public static Coordinates From(int x, int y) {
            return new Coordinates(x, y);
        }
    }
}
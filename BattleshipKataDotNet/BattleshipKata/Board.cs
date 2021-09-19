using System;

namespace BattleshipKata.Tests
{
    public class Board : IEquatable<Board>
    {
        private int width;
        private int heigth;

        public Board(int width, int heigth)
        {
            this.width = width;
            this.heigth = heigth;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Board);
        }

        public bool Equals(Board other)
        {
            return other != null &&
                   width == other.width &&
                   heigth == other.heigth;
        }
    }
}
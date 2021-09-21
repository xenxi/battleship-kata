using System;

namespace BattleshipKata.ValueObjects
{
    public class Size
    {
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; }
        public int Height { get; }

        public bool IsOutsideBoard(Coordinates position)
        {
            return position.X > Width || position.X < 0 || position.Y > Height || position.Y < 0;
        }
    }
}
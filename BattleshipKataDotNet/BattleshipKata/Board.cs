namespace BattleshipKata.Tests
{
    public class Board : IBoard
    {
        public Board(int width, int heigth)
        {
            Width = width;
            Height = heigth;
        }

        public int Height { get; }
        public int Width { get; }
    }
}
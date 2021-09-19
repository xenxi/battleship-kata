using BattleshipKata.Ships;

namespace BattleshipKata.Tests
{
    public class Board : IBoard
    {
        public Board(Size size)
        {
            Size = size;
        }

        public int Height => Size.Height;
        public Size Size { get; }
        public int Width => Size.Width;

        public static Board From(int width, int height)
                    => new Board(new Size(width: width, height: height));

        public void Fire(Coordinates expectedCoordinates)
        {
            throw new System.NotImplementedException();
        }

        public void PlaceShip(Ship ship)
        {
            throw new System.NotImplementedException();
        }
    }
}
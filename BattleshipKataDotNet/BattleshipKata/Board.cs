using BattleshipKata.Ships;

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
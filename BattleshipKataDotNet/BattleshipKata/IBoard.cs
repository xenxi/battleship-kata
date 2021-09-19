using BattleshipKata.Ships;

namespace BattleshipKata.Tests
{
    public interface IBoard
    {
        int Height { get; }
        int Width { get; }

        void PlaceShip(Ship ship);
        void Fire(Coordinates expectedCoordinates);
    }
}
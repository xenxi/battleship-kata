using BattleshipKata.Ships;
using BattleshipKata.ValueObjects;

namespace BattleshipKata.Boards
{
    public interface IBoard
    {
        int Height { get; }
        int Width { get; }

        void PlaceShip(Ship ship);

        void Fire(Coordinates expectedCoordinates);
    }
}
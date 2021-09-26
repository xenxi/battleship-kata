using BattleshipKata.Ships;
using BattleshipKata.ValueObjects;

namespace BattleshipKata.Boards
{
    public interface IBoard
    {
        void PlaceShip(Ship ship);

        void Fire(Coordinates expectedCoordinates);
    }
}
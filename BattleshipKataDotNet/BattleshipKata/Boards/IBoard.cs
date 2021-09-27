using BattleshipKata.Cells;
using BattleshipKata.Ships;
using BattleshipKata.ValueObjects;

namespace BattleshipKata.Boards
{
    public interface IBoard
    {
        ICell[,] Cells { get; }

        void PlaceShip(Ship ship);

        void Fire(Coordinates coordinates);
    }
}
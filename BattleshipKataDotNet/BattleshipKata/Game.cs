using BattleshipKata.Ships;
using BattleshipKata.Tests;
using System.Collections.Generic;

namespace BattleshipKata
{
    public class Game
    {
        private readonly IBoard board;
        private readonly IBoardPrinter printer;

        public Game(IBoard board, IBoardPrinter printer)
        {
            this.board = board;
            this.printer = printer;
        }

        public void Fire(int y, int x)
        {
            board.Fire(new Coordinates(x: x, y: y));
        }

        public void Print()
        {
            printer.Print(board);
        }

        public void Start(IList<Ship> aGivenFleet)
        {
            foreach (var ship in aGivenFleet)
            {
                board.PlaceShip(ship);
            }
        }
    }
}
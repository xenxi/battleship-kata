using BattleshipKata.Tests;
using System;

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
        }

        public void Print()
        {
            printer.Print(board);
        }

        public void Start(object aGivenFleet)
        {
            throw new NotImplementedException();
        }
    }
}
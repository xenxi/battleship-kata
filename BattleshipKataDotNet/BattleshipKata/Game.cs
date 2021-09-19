using BattleshipKata.Tests;

namespace BattleshipKata
{
    public class Game
    {
        private readonly Board board;
        private readonly IBoardPrinter printer;
        public Game(IBoardPrinter printer)
        {
            this.board = new Board(10, 10);
            this.printer = printer;
        }

        public void Fire(int y, int x)
        {
        }

        public void Print()
        {
            printer.Print(board);
        }
    }
}
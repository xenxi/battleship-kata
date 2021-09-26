using BattleshipKata.Boards;

namespace BattleshipKata.Printers
{
    public class BoardPrinter : IBoardPrinter
    {
        private readonly IGamePrinter gamePrinter;

        public BoardPrinter(IGamePrinter gamePrinter)
        {
            this.gamePrinter = gamePrinter;
        }

        public void Print(ICell[,] cells)
        {
            gamePrinter.Print(" | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |");
        }
    }
}
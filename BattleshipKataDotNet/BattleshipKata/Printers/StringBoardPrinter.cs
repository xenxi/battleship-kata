using BattleshipKata.Boards;

namespace BattleshipKata.Printers
{
    public class StringBoardPrinter : IBoardPrinter
    {
        private readonly IGamePrinter gamePrinter;

        public StringBoardPrinter(IGamePrinter gamePrinter)
        {
            this.gamePrinter = gamePrinter;
        }

        public void Print(ICell[,] cells)
        {
            gamePrinter.Print(" | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |");
        }
    }
}
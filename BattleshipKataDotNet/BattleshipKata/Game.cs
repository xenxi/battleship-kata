using System;

namespace BattleshipKata
{
    public class Game
    {
        private readonly IGamePrinter printer;

        public Game(IGamePrinter printer)
        {
            this.printer = printer;
        }

        public void Print()
        {
            printer.Print(" | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |");
            printer.Print("0|   |   |   |   |   |   |   |   |   |   |");
            printer.Print("1|   |   |   |   |   |   |   |   |   |   |");
            printer.Print("2|   |   |   |   |   |   |   |   |   |   |");
            printer.Print("3|   |   |   |   |   |   |   |   |   |   |");
            printer.Print("4|   |   |   |   |   |   |   |   |   |   |");
            printer.Print("5|   |   |   |   |   |   |   |   |   |   |");
            printer.Print("6|   |   |   |   |   |   |   |   |   |   |");
            printer.Print("7|   |   |   |   |   |   |   |   |   |   |");
            printer.Print("8|   |   |   |   |   |   |   |   |   |   |");
            printer.Print("9|   |   |   |   |   |   |   |   |   |   |");

        }

        public void Fire(int y, int x)
        {
        }
    }
}
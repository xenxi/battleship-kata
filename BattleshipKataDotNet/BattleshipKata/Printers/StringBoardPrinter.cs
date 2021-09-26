using BattleshipKata.Boards;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipKata.Printers
{
    public class StringBoardPrinter : IBoardPrinter
    {
        private readonly IStringPrinter printer;

        public StringBoardPrinter(IStringPrinter printer)
        {
            this.printer = printer;
        }

        public void Print(ICell[,] cells)
        {
            var columnNumbers = Enumerable.Range(0, cells.GetLength(0));

            printer.Print($" | {string.Join(" | ", columnNumbers)} |");

            for (int row = 0; row < cells.GetLength(1); row++)
            {
                var rowData = new List<string>();

                for (int col = 0; col < cells.GetLength(0); col++)
                {
                    rowData.Add(" ");
                }

                var rowString = $"{row}| {string.Join(" | ", rowData)} |";

                printer.Print(rowString);
            }
        }
    }
}
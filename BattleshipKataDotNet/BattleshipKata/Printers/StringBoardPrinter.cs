using BattleshipKata.Cells;
using BattleshipKata.Cells.States;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipKata.Printers {
    public class StringBoardPrinter : IBoardPrinter {
        private readonly IStringPrinter printer;

        public StringBoardPrinter(IStringPrinter printer) {
            this.printer = printer;
        }

        public void Print(ICell[,] cells) {
            var cellsStatus = cells
                .OfType<ICell>().Select(cell => cell.Status).ToList();

            PrintPlayerName();

            PrintTotalShots(cellsStatus);
            PrintTotalMisses(cellsStatus);
            PrintTotalHits(cellsStatus);

            var boardWidth = cells.GetLength(0);
            PrintHeader(boardWidth);
            PrintRows(cells);
        }

        private void PrintPlayerName() {
            printer.Print("[ Player1");
        }

        private void PrintTotalMisses(IEnumerable<CellStatus> cellsStatus) {
            var misses = cellsStatus
                .Count(status => status == CellStatus.Failed);

            printer.Print($" Misses: {misses}");
        }

        private void PrintTotalHits(IEnumerable<CellStatus> cellsStatus) {
            var hits = cellsStatus
                .Count(status => status == CellStatus.Hit
                                 || status == CellStatus.Sunk);

            printer.Print($" Hits: {hits}");
        }

        private void PrintTotalShots(IEnumerable<CellStatus> cellsStatus) {
            var totalShots = cellsStatus
                .Count(status => status == CellStatus.Failed
                                 || status == CellStatus.Hit
                                 || status == CellStatus.Sunk);

            printer.Print($" Total shots: {totalShots}");
        }

        private void PrintRows(ICell[,] cells) {
            for (int row = 0; row < cells.GetLength(1); row++)
                PrintRow(cells, row);
        }

        private void PrintRow(ICell[,] cells, int row) {
            var rowData = new List<string>();

            for (int col = 0; col < cells.GetLength(0); col++)
                rowData.Add(StatusToString(cells[col, row].Status));

            var rowString = $"{row}{formatRowData(rowData)}";

            printer.Print(rowString);
        }

        private static string StatusToString(CellStatus status) {
            return status switch {
                CellStatus.Water => " ",
                CellStatus.Destoyer => "d",
                CellStatus.Carrier => "c",
                CellStatus.GunShip => "g",
                CellStatus.Hit => "x",
                CellStatus.Sunk => "X",
                CellStatus.Failed => "o",
                _ => string.Empty,
            };
        }

        private void PrintHeader(int boardWidth) {
            var columnNumbers = Enumerable.Range(0, boardWidth).Select(number => number.ToString());

            string text = $" {formatRowData(columnNumbers)}";
            printer.Print(text);
        }

        private static string formatRowData(IEnumerable<string> data) {
            return $"| {string.Join(" | ", data)} |";
        }
    }
}
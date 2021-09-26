﻿using BattleshipKata.Boards;
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
            PrintHeader(cells);

            PrintRows(cells);
        }

        private void PrintRows(ICell[,] cells)
        {
            for (int row = 0; row < cells.GetLength(1); row++)
                PrintRow(cells, row);
        }

        private void PrintRow(ICell[,] cells, int row)
        {
            var rowData = new List<string>();

            for (int col = 0; col < cells.GetLength(0); col++)
                rowData.Add(StatusToString(cells[col, row].Status));

            var rowString = $"{row}{formatRowData(rowData)}";

            printer.Print(rowString);
        }

        private static string StatusToString(CellStatus status)
        {
            return status switch
            {
                CellStatus.Water => " ",
                CellStatus.Destoyer => "d",
                _ => string.Empty,
            };
        }

        private void PrintHeader(ICell[,] cells)
        {
            var columnNumbers = Enumerable.Range(0, cells.GetLength(0)).Select(number => number.ToString());

            string text = $" {formatRowData(columnNumbers)}";
            printer.Print(text);
        }

        private static string formatRowData(IEnumerable<string> data)
        {
            return $"| {string.Join(" | ", data)} |";
        }
    }
}
using BattleshipKata.Exceptions;
using BattleshipKata.Ships;
using BattleshipKata.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipKata.Boards
{
    public class Board : IBoard
    {
        private readonly Cell[,] cells;

        public Board(Size size)
        {
            cells = CreateCells(size);
            Size = size;
        }

        public ICell[,] Cells => cells;
        public int Height => Size.Height;
        public int Length => cells.Length;
        public Size Size { get; }
        public int Width => Size.Width;
        public static Board From(int width, int height)
            => new Board(new Size(width: width, height: height));

        public Cell CellAt(Coordinates coordinate) => cells[coordinate.X, coordinate.Y];

        public void Fire(Coordinates expectedCoordinates)
        {
            throw new NotImplementedException();
        }

        public void PlaceShip(Ship ship)
        {
            if (!Contains(ship.Coordinates))
                throw new InvalidCoordinates();

            foreach (var coordinate in ship.Coordinates)
                cells[coordinate.X, coordinate.Y] = new Cell(ship);
        }

        private static Cell[,] CreateCells(Size size)
        {
            var grid = new Cell[size.Width, size.Height];
            for (var x = 0; x < size.Width; x++)
            {
                for (var y = 0; y < size.Height; y++)
                {
                    grid[x, y] = Cell.Empty();
                }
            }

            return grid;
        }

        private bool Contains(IList<Coordinates> coordinates) => coordinates.All(x => Contains(x));

        private bool Contains(Coordinates x) => !Size.IsOutsideBoard(x);
    }
}
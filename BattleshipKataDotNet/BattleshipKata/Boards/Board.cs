using BattleshipKata.Exceptions;
using BattleshipKata.Ships;
using BattleshipKata.ValueObjects;
using System;
using System.Collections.Generic;

namespace BattleshipKata.Boards
{
    public class Board : IBoard
    {
        private readonly List<Ship> ships;
        private readonly Cells Cells;

        public Board(Size size)
        {
            Cells = new Cells(size);
            Size = size;
            ships = new List<Ship>();
        }

        public int Height => Size.Height;
        public Size Size { get; }
        public int Width => Size.Width;

        public IReadOnlyList<Ship> GetFleets() => ships.AsReadOnly();

        public static Board From(int width, int height)
            => new Board(new Size(width: width, height: height));

        public void Fire(Coordinates expectedCoordinates)
        {
            throw new NotImplementedException();
        }

        public void PlaceShip(Ship ship)
        {
            if (!Cells.Contains(ship.Coordinates))
                throw new InvalidCoordinates();

            ships.Add(ship);
        }
    }
}
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
        public Board(Size size)
        {
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
            throw new System.NotImplementedException();
        }

        public void PlaceShip(Ship ship)
        {
            if (Size.IsOutsideBoard(ship.Position))
                throw new InvalidCoordinates();

            ships.Add(ship);
        }

  
    }
}
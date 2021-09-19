﻿using BattleshipKata.Ships;

namespace BattleshipKata.Tests
{
    public class Board : IBoard
    {
        public Board(Size size) 
        {
            Width = size.Width;
            Height = size.Height;
        }
        public Board(int width, int height) : this(new Size(width: width, height: height)) { }

        public int Height { get; }
        public int Width { get; }

        public void Fire(Coordinates expectedCoordinates)
        {
            throw new System.NotImplementedException();
        }

        public void PlaceShip(Ship ship)
        {
            throw new System.NotImplementedException();
        }
    }
}
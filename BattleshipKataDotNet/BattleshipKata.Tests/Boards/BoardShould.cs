using BattleshipKata.Boards;
using BattleshipKata.Ships;
using BattleshipKata.Tests.Ships;
using BattleshipKata.ValueObjects;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace BattleshipKata.Tests.Boards
{
    [TestFixture]
    public class BoardShould
    {
        private Board board;

        [Test]
        public void create_new_board_with_correct_size()
        {
            var aGivenBoardSize = new Size(height: 10, width: 15);

            var board = new Board(aGivenBoardSize);

            board.Width.Should().Be(aGivenBoardSize.Width);
            board.Height.Should().Be(aGivenBoardSize.Height);
        }

        [Test]
        public void place_a_ship()
        {
            var aGivenShip = ShipMother.Random();

            board.PlaceShip(aGivenShip);

            board.GetFleets().Should().ContainEquivalentOf(aGivenShip);
        }

        [SetUp]
        public void SetUp()
        {
            board = Board.From(10, 10);
        }

        [Test]
        public void throw_invalid_coordinates_exception_when_place_ship_outside_board()
        {
            var aGivenOutSideBoardCoordinates = CoordinatesMother.CreateOutside(board.Size);
            var aGivenShip = ShipMother.Create(coordinates: aGivenOutSideBoardCoordinates);

            Action action = () => board.PlaceShip(aGivenShip);

            action.Should().Throw<InvalidCoordinates>();
        }
    }
}
using BattleshipKata.Boards;
using BattleshipKata.Exceptions;
using BattleshipKata.Ships;
using BattleshipKata.Tests.Ships;
using BattleshipKata.Tests.ValueObjects;
using BattleshipKata.ValueObjects;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace BattleshipKata.Tests.Boards
{
    [TestFixture]
    public class BoardShould
    {
        private const int HEIGHT = 15;

        private const int WIDTH = 10;

        private Board board;

        [Test]
        public void create_new_board_with_correct_number_of_cells()
        {
            board.Length.Should().Be(WIDTH * HEIGHT);
        }

        [Test]
        public void create_new_board_with_correct_size()
        {
            board.Width.Should().Be(WIDTH);
            board.Height.Should().Be(HEIGHT);
        }

        [Test]
        public void place_a_destroyer()
        {
            var aGivenInitialCoordinates = new Coordinates(0, 0);
            var aGivenDestroyer = new Destroyer(Orientation.Horizontal, aGivenInitialCoordinates);

            board.PlaceShip(aGivenDestroyer);

            foreach (var coordinate in aGivenDestroyer.Coordinates)
                board.CellAt(coordinate).Ship.Should().Be(aGivenDestroyer);
        }

        [SetUp]
        public void SetUp()
        {
            board = Board.From(WIDTH, HEIGHT);
        }
        [TestCase(WIDTH - 1, HEIGHT, 3, Orientation.Horizontal)]
        [TestCase(WIDTH, HEIGHT, 3, Orientation.Horizontal)]
        [TestCase(0, 9, 3, Orientation.Vertical)]
        [TestCase(0, 7, 3, Orientation.Vertical)]
        public void throw_invalid_coordinates_exception_when_not_all_the_squares_of_a_ship_hit_on_the_board(int x, int y, int lenght, Orientation orientation)
        {
            var aGivenShip = ShipMother.Random(position: CoordinatesMother.Create(x, y), orientation: orientation, lenght: lenght);

            Action action = () => board.PlaceShip(aGivenShip);

            action.Should().Throw<InvalidCoordinates>();
        }

        [Test]
        public void throw_invalid_coordinates_exception_when_place_ship_outside_board()
        {
            var aGivenOutSideBoardCoordinates = CoordinatesMother.CreateOutside(board.Size);
            var aGivenShip = ShipMother.Random(position: aGivenOutSideBoardCoordinates);

            Action action = () => board.PlaceShip(aGivenShip);

            action.Should().Throw<InvalidCoordinates>();
        }
    }
}
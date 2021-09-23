using System;
using BattleshipKata.Boards;
using BattleshipKata.Exceptions;
using BattleshipKata.Ships;
using BattleshipKata.Tests.Ships;
using BattleshipKata.Tests.ValueObjects;
using BattleshipKata.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace BattleshipKata.Tests.Boards {
    [TestFixture]
    public class BoardShould {
        [SetUp]
        public void SetUp() {
            board = Board.From(WIDTH, HEIGHT);
        }

        private Board board;
        private const int WIDTH = 10;
        private const int HEIGHT = 15;

        [Test]
        public void create_new_board_with_correct_size() {
            board.Width.Should().Be(WIDTH);
            board.Height.Should().Be(HEIGHT);
        }

        [Test]
        public void place_a_destroyer() {
            var aGivenCoordinates = new Coordinates(0, 0);
            var aGivenDestroyer = new Destroyer(Orientation.Horizontal, aGivenCoordinates);

            board.PlaceShip(aGivenDestroyer);

            board.GetFleets().Should().ContainEquivalentOf(aGivenDestroyer);
        }

        [Test]
        public void throw_invalid_coordinates_exception_when_place_ship_outside_board() {
            var aGivenOutSideBoardCoordinates = CoordinatesMother.CreateOutside(board.Size);
            var aGivenShip = ShipMother.Random(coordinates: aGivenOutSideBoardCoordinates);

            Action action = () => board.PlaceShip(aGivenShip);

            action.Should().Throw<InvalidCoordinates>();
        }

        [TestCase(9, 10, Orientation.Horizontal)]
        [TestCase(10, 10, Orientation.Horizontal)]
        [TestCase(0, 0, Orientation.Vertical)]
        [TestCase(0, 1, Orientation.Vertical)]
        public void throw_invalid_coordinates_exception_when_not_all_the_squares_of_a_ship_hit_on_the_board(int x, int y, Orientation orientation) {
            var aGivenShip = ShipMother.Create(coordinates: CoordinatesMother.Create(x, y), orientation);

            Action action = () => board.PlaceShip(aGivenShip);

            action.Should().Throw<InvalidCoordinates>();
        }
    }
}
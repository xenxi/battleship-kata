using BattleshipKata.Boards;
using BattleshipKata.Printers;
using BattleshipKata.Ships;
using BattleshipKata.Tests.Ships;
using BattleshipKata.ValueObjects;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace BattleshipKata.Tests
{
    [TestFixture]
    public class GameShould
    {
        private IBoard board;
        private Game game;
        private IBoardPrinter printer;

        [Test]
        public void launches_a_torpedo_at_given_coordinates()
        {
            var aGivenYCoordinate = 1;
            var aGivenXCoordinate = 2;

            game.Fire(x: aGivenXCoordinate, y: aGivenYCoordinate);

            var expectedCoordinates = new Coordinates(x: aGivenXCoordinate, y: aGivenYCoordinate);
            board.Received(1).Fire(expectedCoordinates);
        }

        [Test]
        public void print_a_empty_game()
        {
            game.Print();

            printer.Received(1).Print(board);
        }

        [SetUp]
        public void SetUp()
        {
            printer = Substitute.For<IBoardPrinter>();
            board = Substitute.For<IBoard>();

            game = new Game(board, printer);
        }

        [Test]
        public void start_a_game_with_fleet_of_ships()
        {
            var aGivenFleet = DestroyerMother.Randoms();

            game.Start(aGivenFleet);

            aGivenFleet.ForEach(ship => board.Received(1).PlaceShip(ship));
        }
    }
}
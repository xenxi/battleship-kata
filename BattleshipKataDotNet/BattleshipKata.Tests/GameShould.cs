using BattleshipKata.Ships;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace BattleshipKata.Tests
{
    [TestFixture]
    public class GameShould
    {
        private Game game;
        private IBoardPrinter printer;
        private IBoard board;

        [Test]
        public void print_a_empty_game()
        {
            game.Print();

            printer.Received(1).Print(board);
        }

        [Test]
        public void start_a_game_with_fleet_of_ships()
        {
            var aGivenFleet = new List<Ship> { new Ship(), new Ship() };

            game.Start(aGivenFleet);

            aGivenFleet.ForEach(ship => board.Received(1).PlaceShip(ship));
        }

        [SetUp]
        public void SetUp()
        {
            printer = Substitute.For<IBoardPrinter>();
            board = Substitute.For<IBoard>();

            game = new Game(board, printer);
        }
    }
}
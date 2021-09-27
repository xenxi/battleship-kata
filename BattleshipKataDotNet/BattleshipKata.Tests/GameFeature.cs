using BattleshipKata.Boards;
using BattleshipKata.Printers;
using BattleshipKata.Ships;
using BattleshipKata.ValueObjects;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace BattleshipKata.Tests
{
    [TestFixture]
    public class GameFeature
    {
        private IStringPrinter gamePrinter;
        private Game game;

        [SetUp]
        public void SetUp()
        {
            gamePrinter = Substitute.For<IStringPrinter>();
            StringBoardPrinter printer = new StringBoardPrinter(gamePrinter);
            var board = Board.From(10, 10);

            game = new Game(board, printer);
        }

        [Test]
        public void print_empty_game_report()
        {
            var aGivenFleet = AGivenFleet();
            game.Start(aGivenFleet);

            game.Print();

            Received.InOrder(() =>
            {
                gamePrinter.Print(" | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |");
                gamePrinter.Print("0|   |   |   |   |   |   |   |   |   |   |");
                gamePrinter.Print("1|   |   |   |   |   |   |   |   |   |   |");
                gamePrinter.Print("2|   |   |   |   |   |   |   | g |   |   |");
                gamePrinter.Print("3|   |   | d | d | d |   |   |   |   |   |");
                gamePrinter.Print("4|   |   |   |   |   |   | g |   | c |   |");
                gamePrinter.Print("5|   |   |   |   |   |   |   |   | c |   |");
                gamePrinter.Print("6|   |   |   |   |   |   |   |   | c |   |");
                gamePrinter.Print("7|   | g |   |   |   | d |   |   | c |   |");
                gamePrinter.Print("8|   |   |   |   |   | d |   |   |   |   |");
                gamePrinter.Print("9|   |   |   |   |   | d |   |   |   | g |");
            });
        }

        [Test]
        public void print_played_game_report()
        {
            var aGivenFleet = AGivenFleet();
            game.Start(aGivenFleet);
            aGivenPlayerShots(game);

            game.Print();

            Received.InOrder(() =>
            {
                gamePrinter.Print(" | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |");
                gamePrinter.Print("0|   |   | o |   |   |   |   |   |   |   |");
                gamePrinter.Print("1|   | o |   | o |   |   |   |   |   |   |");
                gamePrinter.Print("2|   | o |   |   |   |   |   | X |   |   |");
                gamePrinter.Print("3|   |   | X | X | X |   |   |   |   |   |");
                gamePrinter.Print("4|   | o |   |   |   |   | g |   | c |   |");
                gamePrinter.Print("5|   | o | o |   |   | o |   |   | c |   |");
                gamePrinter.Print("6|   |   |   | o |   |   | o |   | c |   |");
                gamePrinter.Print("7|   | X |   |   |   | d |   |   | x |   |");
                gamePrinter.Print("8|   |   | o | o |   | d |   |   | o |   |");
                gamePrinter.Print("9|   |   |   |   | o | x | o |   |   | X |");
            });
        }

        private static List<Ship> AGivenFleet()
        {
            return new List<Ship>
            {
                new GunShip(new Coordinates(x: 7, y: 2)),
                new Destroyer(Orientation.Horizontal, new Coordinates(x: 2, y: 3)),
                new GunShip(new Coordinates(x: 6, y: 4)),
                new Carrier(Orientation.Vertical, new Coordinates(x: 8, y: 4)),
                new GunShip(new Coordinates(x: 1, y: 7)),
                new Destroyer(Orientation.Vertical, new Coordinates(x: 5, y: 7)),
                new GunShip(new Coordinates(x: 9, y: 9)),
            };
        }

        private static void aGivenPlayerShots(Game game)
        {
            game.Fire(x: 2, y: 0);

            game.Fire(x: 1, y: 1);
            game.Fire(x: 3, y: 1);

            game.Fire(x: 1, y: 2);
            game.Fire(x: 7, y: 2);

            game.Fire(x: 2, y: 3);
            game.Fire(x: 3, y: 3);
            game.Fire(x: 4, y: 3);

            game.Fire(x: 1, y: 4);

            game.Fire(x: 1, y: 5);
            game.Fire(x: 2, y: 5);
            game.Fire(x: 5, y: 5);

            game.Fire(x: 3, y: 6);
            game.Fire(x: 6, y: 6);

            game.Fire(x: 1, y: 7);
            game.Fire(x: 8, y: 7);

            game.Fire(x: 2, y: 8);
            game.Fire(x: 3, y: 8);
            game.Fire(x: 8, y: 8);

            game.Fire(x: 4, y: 9);
            game.Fire(x: 5, y: 9);
            game.Fire(x: 6, y: 9);
            game.Fire(x: 9, y: 9);
        }
    }
}
using NSubstitute;
using NUnit.Framework;

namespace BattleshipKata.Tests
{
    [TestFixture]
    public class GameFeature
    {
        private IGamePrinter gamePrinter;
        private Game game;

        [SetUp]
        public void SetUp()
        {
            gamePrinter = Substitute.For<IGamePrinter>();
            game = new Game(gamePrinter);
        }

        [Test]
        public void print_game_report()
        {
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
            game.Fire(x: 6, y: 4);
            game.Fire(x: 8, y: 4);
            game.Fire(x: 1, y: 5);
            game.Fire(x: 2, y: 5);
            game.Fire(x: 5, y: 5);
            game.Fire(x: 8, y: 5);
            game.Fire(x: 3, y: 6);
            game.Fire(x: 6, y: 6);
            game.Fire(x: 8, y: 6);
            game.Fire(x: 1, y: 7);
            game.Fire(x: 5, y: 7);
            game.Fire(x: 8, y: 7);
            game.Fire(x: 2, y: 8);
            game.Fire(x: 3, y: 8);
            game.Fire(x: 5, y: 8);
            game.Fire(x: 8, y: 8);
            game.Fire(x: 4, y: 9);
            game.Fire(x: 5, y: 9);
            game.Fire(x: 6, y: 9);
            game.Fire(x: 9, y: 9);
        }
    }
}
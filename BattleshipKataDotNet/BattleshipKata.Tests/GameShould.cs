using NSubstitute;
using NUnit.Framework;

namespace BattleshipKata.Tests
{
    [TestFixture]
    public class GameShould
    {
        private IGamePrinter gamePrinter;
        private Game game;

        [SetUp]
        public void SetUp()
        {
            gamePrinter = Substitute.For<IGamePrinter>();
            game = new Game();
        }

        [Test]
        public void print_a_empty_game()
        {
            game.Print();

            Received.InOrder(() => {
                gamePrinter.Print(" | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |");
                gamePrinter.Print("0|   |   |   |   |   |   |   |   |   |   |");
                gamePrinter.Print("1|   |   |   |   |   |   |   |   |   |   |");
                gamePrinter.Print("2|   |   |   |   |   |   |   |   |   |   |");
                gamePrinter.Print("3|   |   |   |   |   |   |   |   |   |   |");
                gamePrinter.Print("4|   |   |   |   |   |   |   |   |   |   |");
                gamePrinter.Print("5|   |   |   |   |   |   |   |   |   |   |");
                gamePrinter.Print("6|   |   |   |   |   |   |   |   |   |   |");
                gamePrinter.Print("7|   |   |   |   |   |   |   |   |   |   |");
                gamePrinter.Print("8|   |   |   |   |   |   |   |   |   |   |");
                gamePrinter.Print("9|   |   |   |   |   |   |   |   |   |   |");
            });
        }
    }
}
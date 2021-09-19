using NSubstitute;
using NUnit.Framework;

namespace BattleshipKata.Tests
{
    [TestFixture]
    public class GameShould
    {
        private Game game;
        private IBoardPrinter printer;
        [Test]
        public void print_a_empty_game()
        {
            game.Print();

            var expectedEmptyBoard = new Board(width: 10, heigth: 10);
            printer.Received(1).Print(expectedEmptyBoard);
        }

        [SetUp]
        public void SetUp()
        {
            printer = Substitute.For<IBoardPrinter>();
            game = new Game(printer);
        }
    }
}
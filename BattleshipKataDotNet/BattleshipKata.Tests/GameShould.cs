using NSubstitute;
using NUnit.Framework;

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

        [SetUp]
        public void SetUp()
        {
            printer = Substitute.For<IBoardPrinter>();
            board = Substitute.For<IBoard>();

            game = new Game(board, printer);
        }
    }
}
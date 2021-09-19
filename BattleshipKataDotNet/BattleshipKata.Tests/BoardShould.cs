using FluentAssertions;
using NUnit.Framework;

namespace BattleshipKata.Tests
{
    [TestFixture]
    public class BoardShould
    {
        [Test]
        public void create_new_board_with_correct_size()
        {
            var aGivenBoardSize = new Size(height: 10, width: 15);

            var board = new Board(aGivenBoardSize);

            board.Width.Should().Be(aGivenBoardSize.Width);
            board.Height.Should().Be(aGivenBoardSize.Height);
        }
    }
}
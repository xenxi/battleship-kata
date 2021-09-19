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
            var aGivenHeigh = 10;
            var aGivenWidth = 15;

            var board = new Board(heigth: aGivenHeigh, width: aGivenWidth);

            board.Height.Should().Be(aGivenHeigh);
            board.Width.Should().Be(aGivenWidth);
        }
    }
}
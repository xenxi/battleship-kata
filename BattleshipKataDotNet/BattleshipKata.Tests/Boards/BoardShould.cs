using BattleshipKata.Boards;
using BattleshipKata.Ships;
using BattleshipKata.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace BattleshipKata.Tests.Boards
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

        [Test]
        public void place_a_ship()
        {
            var aGivenShip = new Ship();
            var board = Board.From(10,10);

            board.PlaceShip(aGivenShip);

            board.GetFleets().Should().ContainEquivalentOf(aGivenShip);
        }
    }
}
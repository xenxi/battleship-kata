using BattleshipKata.Boards;
using FluentAssertions;
using NUnit.Framework;

namespace BattleshipKata.Tests.Boards
{
    [TestFixture]
    public class CellShould
    {
        [Test]
        public void has_water_status_by_default()
        {
            var cell = Cell.Empty();

            cell.Status.Should().Be(CellStatus.Water);
        }

        [Test]
        public void has_failed_status_when_shoots_and_has_no_ship()
        {
            var cell = Cell.Empty();

            cell.Fire();

            cell.Status.Should().Be(CellStatus.Failed);
        }
    }
}
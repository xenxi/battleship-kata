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
            var cell = Cell.WaterCell();

            cell.Status.Should().Be(CellStatus.Water);
        }
    }
}
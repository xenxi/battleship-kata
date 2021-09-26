using BattleshipKata.Boards;
using BattleshipKata.Tests.Ships;
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

        [Test]
        public void has_destroyer_status_when_has_a_destructor()
        {
            var aGivenDestoyer = ShipMother.Random();
            var cell = new Cell(aGivenDestoyer);

            cell.Status.Should().Be(CellStatus.Destoyer);
        }

        [Test]
        public void has_sunk_status_when_shoots_and_has_ship_with_one_life()
        {
            var cell = AGivenCellWithShipWithOneLife();

            cell.Fire();

            cell.Status.Should().Be(CellStatus.Sunk);
        }

        private static Cell AGivenCellWithShipWithOneLife()
        {
            var aGivenDestoyer = ShipMother.Random();
            var cell = new Cell(aGivenDestoyer);
            for (int i = 0; i < aGivenDestoyer.Coordinates.Count - 1; i++)
                aGivenDestoyer.Shot();
            return cell;
        }
    }
}
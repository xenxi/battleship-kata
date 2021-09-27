using BattleshipKata.Ships;
using BattleshipKata.Tests.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace BattleshipKata.Tests.Ships
{
    [TestFixture]
    public class GunShipShould
    {
        private GunShip gunShip;

        [Test]
        public void has_one_coordinates()
        {
            gunShip.Coordinates.Count.Should().Be(1);
        }

        [Test]
        public void has_one_live()
        {
            gunShip.Lives.Should().Be(1);
        }

        [Test]
        public void has_type_gun_ship()
        {
            gunShip.Type.Should().Be(ShipType.GunShip);
        }

        [SetUp]
        public void SetUp()
        {
            gunShip = new GunShip(CoordinatesMother.Random());
        }
    }
}
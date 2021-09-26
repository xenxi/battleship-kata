using BattleshipKata.Ships;
using BattleshipKata.Tests.ValueObjects;
using BattleshipKata.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace BattleshipKata.Tests.Ships
{
    [TestFixture]
    public class CarrierShould
    {
        private Carrier carrier;

        [Test]
        public void has_four_coordinates()
        {
            carrier.Coordinates.Count.Should().Be(4);
        }

        [Test]
        public void has_four_lives()
        {
            carrier.Lives.Should().Be(4);
        }

        [Test]
        public void has_type_carrier()
        {
            carrier.Type.Should().Be(ShipType.Carrier);
        }

        [SetUp]
        public void SetUp()
        {
            carrier = new Carrier(Orientation.Horizontal, CoordinatesMother.Random());
        }
    }
}
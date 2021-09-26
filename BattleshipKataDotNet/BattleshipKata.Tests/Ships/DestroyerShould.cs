using BattleshipKata.Ships;
using BattleshipKata.Tests.ValueObjects;
using BattleshipKata.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace BattleshipKata.Tests.Ships
{
    [TestFixture]
    public class DestroyerShould
    {
        private Destroyer destroyer;

        [Test]
        public void has_three_coordinates()
        {
            destroyer.Coordinates.Count.Should().Be(3);
        }

        [Test]
        public void has_three_lives()
        {
            destroyer.Lives.Should().Be(3);
        }

        [Test]
        public void has_type_destroyer()
        {
            destroyer.Type.Should().Be(ShipType.Destroyer);
        }

        [SetUp]
        public void SetUp()
        {
            destroyer = new Destroyer(Orientation.Horizontal, CoordinatesMother.Random());
        }
    }
}
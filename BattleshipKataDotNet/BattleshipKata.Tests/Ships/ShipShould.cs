using BattleshipKata.Tests.ValueObjects;
using BattleshipKata.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace BattleshipKata.Tests.Ships
{
    [TestFixture]
    public class ShipShould
    {
        [TestCase(10)]
        [TestCase(45)]
        public void has_same_number_of_lives_as_length(int aGivenLength)
        {
            var ship = AGivenShipWith(aGivenLength);

            ship.Lives.Should().Be(aGivenLength);
        }

        [Test]
        public void lose_a_life_when_shot()
        {
            int aGivenLength = 10;
            var ship = AGivenShipWith(aGivenLength);

            ship.Shot();

            int expectedLives = aGivenLength - 1;
            ship.Lives.Should().Be(expectedLives);
        }

        private static ShipFake AGivenShipWith(int aGivenLength) => new ShipFake(Orientation.Horizontal, aGivenLength, CoordinatesMother.Random());
    }
}
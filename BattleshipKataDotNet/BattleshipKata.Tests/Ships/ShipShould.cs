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
            var aGivenShip = AGivenShip(aGivenLength);

            aGivenShip.Lives.Should().Be(aGivenLength);
        }

        [Test]
        public void lose_a_life_when_shot()
        {
            int aGivenLength = 10;
            var aGivenShip = AGivenShip(aGivenLength);

            aGivenShip.Shot();

            int expectedLives = aGivenLength - 1;
            aGivenShip.Lives.Should().Be(expectedLives);
        }

        private static ShipFake AGivenShip(int aGivenLength = 10) => new ShipFake(Orientation.Horizontal, aGivenLength, CoordinatesMother.Random());
    }
}
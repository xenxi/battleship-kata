using BattleshipKata.Ships;
using BattleshipKata.Tests.ValueObjects;
using BattleshipKata.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace BattleshipKata.Tests.Ships
{
    [TestFixture]
    public class ShipShould
    {
        [Test]
        public void has_not_touched_status_when_has_not_been_shot()
        {
            var aGivenShip = AGivenShip();

            aGivenShip.State.Should().Be(ShipStatus.NotTouched);
        }

        [TestCase(10)]
        [TestCase(45)]
        public void has_same_number_of_lives_as_length(int aGivenLength)
        {
            var aGivenShip = AGivenShip(aGivenLength);

            aGivenShip.Lives.Should().Be(aGivenLength);
        }

        [TestCase(10)]
        [TestCase(4)]
        public void has_same_number_of_coordinates_as_length(int aGivenLength) {

            var aGivenShip = AGivenShip(aGivenLength);

            aGivenShip.Coordinates.Count.Should().Be(aGivenLength);
        }

        [Test]
        public void has_sunken_status_when_shot_and_has_no_lives_left()
        {
            var aGivenShip = AGivenShipWithOneLive();

            aGivenShip.Shot();

            aGivenShip.State.Should().Be(ShipStatus.Sunken);
        }

        [Test]
        public void has_touched_status_when_has_shot()
        {
            var aGivenShip = AGivenShip();

            aGivenShip.Shot();

            aGivenShip.State.Should().Be(ShipStatus.Touched);
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

        private Ship AGivenShipWithOneLive() => AGivenShip(1);
    }
}
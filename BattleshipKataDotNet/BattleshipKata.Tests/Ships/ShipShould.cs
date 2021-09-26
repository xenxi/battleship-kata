using BattleshipKata.Ships;
using BattleshipKata.ValueObjects;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace BattleshipKata.Tests.Ships
{
    [TestFixture]
    public class ShipShould
    {
        [Test]
        public void has_correct_coordinates_when_created_horizontally()
        {
            var aGivenShip = ShipMother.Random(orientation: Orientation.Horizontal, lenght: 3, position: new Coordinates(1, 1));

            List<Coordinates> expectedCoordinates = new List<Coordinates> {
                new Coordinates(1,1),
                new Coordinates(2,1),
                new Coordinates(3,1),
            };
            aGivenShip.Coordinates.Should().ContainInOrder(expectedCoordinates);
        }

        [Test]
        public void has_correct_coordinates_when_created_vertically()
        {
            var aGivenShip = ShipMother.Random(orientation: Orientation.Vertical, lenght: 3, position: new Coordinates(1, 3));

            List<Coordinates> expectedCoordinates = new List<Coordinates> {
                new Coordinates(1, 3),
                new Coordinates(1, 2),
                new Coordinates(1, 1),
            };
            aGivenShip.Coordinates.Should().ContainInOrder(expectedCoordinates);
        }

        [Test]
        public void has_not_touched_status_when_has_not_been_shot()
        {
            var aGivenShip = ShipMother.Random();

            aGivenShip.State.Should().Be(ShipStatus.NotTouched);
        }

        [TestCase(10)]
        [TestCase(4)]
        public void has_same_number_of_coordinates_as_length(int aGivenLength)
        {
            var aGivenShip = ShipMother.Random(lenght: aGivenLength);

            aGivenShip.Coordinates.Count.Should().Be(aGivenLength);
        }

        [TestCase(10)]
        [TestCase(45)]
        public void has_same_number_of_lives_as_length(int aGivenLength)
        {
            var aGivenShip = ShipMother.Random(lenght: aGivenLength);

            aGivenShip.Lives.Should().Be(aGivenLength);
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
            var aGivenShip = ShipMother.Random(lenght: 2);

            aGivenShip.Shot();

            aGivenShip.State.Should().Be(ShipStatus.Touched);
        }

        [Test]
        public void lose_a_life_when_shot()
        {
            int aGivenLength = 10;
            var aGivenShip = ShipMother.Random(lenght: aGivenLength);

            aGivenShip.Shot();

            int expectedLives = aGivenLength - 1;
            aGivenShip.Lives.Should().Be(expectedLives);
        }

        private Ship AGivenShipWithOneLive() => ShipMother.Random(lenght: 1);
    }
}
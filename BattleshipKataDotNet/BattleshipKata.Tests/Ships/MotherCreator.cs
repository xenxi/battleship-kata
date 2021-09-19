using Bogus;

namespace BattleshipKata.Tests.Ships
{
    public static class MotherCreator
    {
        public static Randomizer Random() => new Faker().Random;
    }
}
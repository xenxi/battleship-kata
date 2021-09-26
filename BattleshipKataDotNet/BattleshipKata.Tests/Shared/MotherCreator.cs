using Bogus;

namespace BattleshipKata.Tests.Shared
{
    public static class MotherCreator
    {
        public static Randomizer Random() => new Faker().Random;
    }
}
using BattleshipKata.Tests.Shared;
using BattleshipKata.ValueObjects;

namespace BattleshipKata.Tests.ValueObjects
{
    public static class OrientationMother
    {
        public static Orientation Random()
        {
            return MotherCreator.Random().Enum<Orientation>();
        }
    }
}
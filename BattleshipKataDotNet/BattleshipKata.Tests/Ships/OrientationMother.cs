using BattleshipKata.ValueObjects;

namespace BattleshipKata.Tests.Ships
{
    public static class OrientationMother {
        public static Orientation Random() {
            return MotherCreator.Random().Enum<Orientation>();
        }
    }
}
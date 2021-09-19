using BattleshipKata.ValueObjects;

namespace BattleshipKata.Tests.Ships
{
    public static class CoordinatesMother
    {
        public const int DefaultMax = 10;

        public static Coordinates Create(int x, int y)
        {
            return new Coordinates(x: x, y: y);
        }

        public static Coordinates CreateOutside(Size size)
        {
            var x = MotherCreator.Random().Number(min: size.Width + 1);
            var y = MotherCreator.Random().Number(max: size.Height + 1);

            return Create(x: x, y: y);
        }

        public static Coordinates Random(int maxX = DefaultMax, int maxY = DefaultMax)
        {
            var x = MotherCreator.Random().Number(max: maxX);
            var y = MotherCreator.Random().Number(max: maxY);

            return Create(x: x, y: y);
        }
    }
}
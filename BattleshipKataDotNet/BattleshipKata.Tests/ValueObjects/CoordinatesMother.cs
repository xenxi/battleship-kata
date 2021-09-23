using BattleshipKata.Tests.Ships;
using BattleshipKata.ValueObjects;

namespace BattleshipKata.Tests.ValueObjects
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
            var x = MotherCreator.Random().Number(min: size.Width + 1, max: size.Height * 2);
            var y = MotherCreator.Random().Number(min: size.Height + 1, max: size.Height * 2);

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
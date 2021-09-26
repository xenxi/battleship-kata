using BattleshipKata.Tests.Shared;
using BattleshipKata.ValueObjects;

namespace BattleshipKata.Tests.ValueObjects
{
    public static class SizeMother
    {
        public static Size Create(int height, int width) => new Size(width: width, height: height);

        public static Size Random(int? height = null, int? width = null) => Create(
            width: width ?? MotherCreator.Random().Number(min: 1, max: 10),
            height: height ?? MotherCreator.Random().Number(min: 1, max: 10));
    }
}
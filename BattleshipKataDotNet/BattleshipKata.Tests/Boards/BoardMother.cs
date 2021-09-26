using BattleshipKata.Boards;
using BattleshipKata.Tests.ValueObjects;
using BattleshipKata.ValueObjects;

namespace BattleshipKata.Tests.Boards
{
    public static class BoardMother
    {
        public static IBoard Create(Size size)
            => new Board(size);

        public static IBoard Random(Size size = null)
         => Create(size: size ?? SizeMother.Random());
    }
}
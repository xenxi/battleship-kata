using BattleshipKata.Printers;
using BattleshipKata.Tests.Boards;
using BattleshipKata.Tests.ValueObjects;
using NSubstitute;
using NUnit.Framework;

namespace BattleshipKata.Tests.Printers
{
    [TestFixture]
    public class BoardPrinterShould
    {
        [Test]
        public void print_header()
        {
            var gamePrinter = Substitute.For<IGamePrinter>();
            var aGivenBoard = BoardMother.Random(size: SizeMother.Random(width: 10));
            var printer = new BoardPrinter(gamePrinter);

            printer.Print(aGivenBoard.Cells);

            gamePrinter.Received(1).Print(" | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |");
        }
    }
}
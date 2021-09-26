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
        private IStringPrinter gamePrinter;
        private StringBoardPrinter printer;

        [Test]
        public void print_header()
        {
            var aGivenBoard = BoardMother.Random(size: SizeMother.Random(width: 10));

            printer.Print(aGivenBoard.Cells);

            gamePrinter.Received(1).Print(" | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |");
        }

        [SetUp]
        public void SetUp()
        {
            gamePrinter = Substitute.For<IStringPrinter>();
            printer = new StringBoardPrinter(gamePrinter);
        }
    }
}
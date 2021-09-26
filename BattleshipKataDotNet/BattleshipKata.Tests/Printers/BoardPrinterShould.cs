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

        [TestCase(10, " | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |")]
        [TestCase(5, " | 0 | 1 | 2 | 3 | 4 |")]
        public void print_header(int aGivenWidth, string expectedHeader)
        {
            var aGivenBoard = BoardMother.Random(size: SizeMother.Random(width: aGivenWidth));

            printer.Print(aGivenBoard.Cells);

            gamePrinter.Received(1).Print(expectedHeader);
        }
       
        [SetUp]
        public void SetUp()
        {
            gamePrinter = Substitute.For<IStringPrinter>();
            printer = new StringBoardPrinter(gamePrinter);
        }
    }
}
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
       
        [Test]
        public void print_empty_board()
        {
            var aGivenBoard = BoardMother.Random(size: SizeMother.Random(width: 10, height: 9));

            printer.Print(aGivenBoard.Cells);

            Received.InOrder(() =>
            {
                gamePrinter.Print(" | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |");
                gamePrinter.Print("0|   |   |   |   |   |   |   |   |   |   |");
                gamePrinter.Print("1|   |   |   |   |   |   |   |   |   |   |");
                gamePrinter.Print("2|   |   |   |   |   |   |   |   |   |   |");
                gamePrinter.Print("3|   |   |   |   |   |   |   |   |   |   |");
                gamePrinter.Print("4|   |   |   |   |   |   |   |   |   |   |");
                gamePrinter.Print("5|   |   |   |   |   |   |   |   |   |   |");
                gamePrinter.Print("6|   |   |   |   |   |   |   |   |   |   |");
                gamePrinter.Print("7|   |   |   |   |   |   |   |   |   |   |");
                gamePrinter.Print("8|   |   |   |   |   |   |   |   |   |   |");
            });
        }
        [SetUp]
        public void SetUp()
        {
            gamePrinter = Substitute.For<IStringPrinter>();
            printer = new StringBoardPrinter(gamePrinter);
        }
    }
}
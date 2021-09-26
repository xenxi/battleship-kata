using BattleshipKata.Boards;
using BattleshipKata.Printers;
using BattleshipKata.Tests.Boards;
using BattleshipKata.Tests.ValueObjects;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace BattleshipKata.Tests.Printers
{
    [TestFixture]
    public class BoardPrinterShould
    {
        private IStringPrinter gamePrinter;
        private StringBoardPrinter printer;

        [TestCaseSource(nameof(TestCasesForEmptyBoards))]
        public void print_empty_board((IBoard aGivenBoard, List<string> expectedOutput) emptyBoardData)
        {
            printer.Print(emptyBoardData.aGivenBoard.Cells);

            Received.InOrder(() => emptyBoardData.expectedOutput.ForEach(line => gamePrinter.Print(line)));
        }

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

        private static IEnumerable<(IBoard aGivenBoard, List<string> expectedOutput)> TestCasesForEmptyBoards()
        {
            yield return (BoardMother.Random(size: SizeMother.Random(width: 10, height: 9)), new List<string> {
             " | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |",
             "0|   |   |   |   |   |   |   |   |   |   |",
             "1|   |   |   |   |   |   |   |   |   |   |",
             "2|   |   |   |   |   |   |   |   |   |   |",
             "3|   |   |   |   |   |   |   |   |   |   |",
             "4|   |   |   |   |   |   |   |   |   |   |",
             "5|   |   |   |   |   |   |   |   |   |   |",
             "6|   |   |   |   |   |   |   |   |   |   |",
             "7|   |   |   |   |   |   |   |   |   |   |",
             "8|   |   |   |   |   |   |   |   |   |   |",
        });

            yield return (BoardMother.Random(size: SizeMother.Random(width: 6, height: 3)), new List<string> {
             " | 0 | 1 | 2 | 3 | 4 | 5 |",
             "0|   |   |   |   |   |   |",
             "1|   |   |   |   |   |   |",
             "2|   |   |   |   |   |   |"
        });
        }
    }
}
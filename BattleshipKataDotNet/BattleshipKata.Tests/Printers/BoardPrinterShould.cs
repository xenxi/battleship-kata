using BattleshipKata.Boards;
using BattleshipKata.Printers;
using BattleshipKata.Ships;
using BattleshipKata.Tests.Boards;
using BattleshipKata.Tests.Ships;
using BattleshipKata.Tests.ValueObjects;
using BattleshipKata.ValueObjects;
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

        [Test]
        public void print_carrier()
        {
            var aGivenBoard = BoardMother.Random(size: SizeMother.Random(width: 10, height: 10));
            var aGivenDestroyer = new Carrier(Orientation.Vertical, new Coordinates(x: 8, y: 4));
            aGivenBoard.PlaceShip(aGivenDestroyer);

            printer.Print(aGivenBoard.Cells);

            Received.InOrder(() =>
            {
                gamePrinter.Print("4|   |   |   |   |   |   |   |   | c |   |");
                gamePrinter.Print("5|   |   |   |   |   |   |   |   | c |   |");
                gamePrinter.Print("6|   |   |   |   |   |   |   |   | c |   |");
                gamePrinter.Print("7|   |   |   |   |   |   |   |   | c |   |");
            });
        }

        [Test]
        public void print_destroyer()
        {
            var aGivenBoard = BoardMother.Random(size: SizeMother.Random(width: 10, height: 5));
            var aGivenDestroyer = new Destroyer(Orientation.Horizontal, new Coordinates(x: 2, y: 3));
            aGivenBoard.PlaceShip(aGivenDestroyer);

            printer.Print(aGivenBoard.Cells);

            gamePrinter.Received(1).Print("3|   |   | d | d | d |   |   |   |   |   |");
        }

        [TestCaseSource(nameof(TestCasesForEmptyBoards))]
        public void print_empty_board((IBoard board, List<string> strOutputs) testCaseData)
        {
            var (aGivenBoard, expectedOutput) = testCaseData;

            printer.Print(aGivenBoard.Cells);

            Received.InOrder(() => expectedOutput.ForEach(line => gamePrinter.Print(line)));
        }

        [Test]
        public void print_failed_shot()
        {
            var aGivenBoard = BoardMother.Random(size: SizeMother.Random(width: 10, height: 5));
            aGivenBoard.Fire(new Coordinates(x: 3, y: 3));

            printer.Print(aGivenBoard.Cells);

            gamePrinter.Received(1).Print("3|   |   |   | o |   |   |   |   |   |   |");
        }

        [Test]
        public void print_gun_ship()
        {
            var aGivenBoard = BoardMother.Random(size: SizeMother.Random(width: 10, height: 10));
            var aGivenDestroyer = new GunShip(new Coordinates(x: 1, y: 1));
            aGivenBoard.PlaceShip(aGivenDestroyer);

            printer.Print(aGivenBoard.Cells);

            gamePrinter.Received(1).Print("1|   | g |   |   |   |   |   |   |   |   |");
        }

        [TestCase(10, " | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |")]
        [TestCase(5, " | 0 | 1 | 2 | 3 | 4 |")]
        public void print_header(int aGivenWidth, string expectedHeader)
        {
            var aGivenBoard = BoardMother.Random(size: SizeMother.Random(width: aGivenWidth));

            printer.Print(aGivenBoard.Cells);

            gamePrinter.Received(1).Print(expectedHeader);
        }

        [Test]
        public void print_hit_ship()
        {
            var aGivenBoard = BoardMother.Random(size: SizeMother.Random(width: 10, height: 5));
            var aGivenDestroyer = new Destroyer(Orientation.Horizontal, new Coordinates(x: 2, y: 3));
            aGivenBoard.PlaceShip(aGivenDestroyer);
            aGivenBoard.Fire(new Coordinates(x: 3, y: 3));

            printer.Print(aGivenBoard.Cells);

            gamePrinter.Received(1).Print("3|   |   | d | x | d |   |   |   |   |   |");
        }

        [Test]
        public void print_sunk_ship()
        {
            var aGivenBoard = BoardMother.Random(size: SizeMother.Random(width: 10, height: 5));
            var aGivenDestroyer = new Destroyer(Orientation.Horizontal, new Coordinates(x: 2, y: 3));
            aGivenBoard.PlaceShip(aGivenDestroyer);
            aGivenBoard.Fire(new Coordinates(x: 2, y: 3));
            aGivenBoard.Fire(new Coordinates(x: 3, y: 3));
            aGivenBoard.Fire(new Coordinates(x: 4, y: 3));

            printer.Print(aGivenBoard.Cells);

            gamePrinter.Received(1).Print("3|   |   | X | X | X |   |   |   |   |   |");
        }

        [TestCaseSource(nameof(TestCasesForPrintMisses))]
        public void print_total_misses((IBoard board, string outputStr) testCaseData)
        {
            var (aGivenBoard, expectedOutput) = testCaseData;

            printer.Print(aGivenBoard.Cells);

            gamePrinter.Received(1).Print(expectedOutput);
        }
        [TestCaseSource(nameof(TestCasesForPrintHits))]
        public void print_total_hits((IBoard board, string outputStr) testCaseData)
        {
            var (aGivenBoard, expectedOutput) = testCaseData;

            printer.Print(aGivenBoard.Cells);

            gamePrinter.Received(1).Print(expectedOutput);
        }
        [TestCaseSource(nameof(TestCasesForPrintTotalShots))]
        public void print_total_shots((IBoard board, string outputStr) testCaseData)
        {
            var (aGivenBoard, expectedOutput) = testCaseData;

            printer.Print(aGivenBoard.Cells);

            gamePrinter.Received(1).Print(expectedOutput);
        }

        [Test]
        public void print_player_name() {
            var aGivenBoard = BoardMother.Random();

            printer.Print(aGivenBoard.Cells);
            
            gamePrinter.Received(1).Print("[ Player1");
        }
        [SetUp]
        public void SetUp()
        {
            gamePrinter = Substitute.For<IStringPrinter>();
            printer = new StringBoardPrinter(gamePrinter);
        }

        private static IBoard BoardWithThreeSunkedShots()
        {
            var board = BoardMother.Random(SizeMother.Random(width: 10));

            board.PlaceShip(ShipMother.Random(lenght: 3, position: Coordinates.From(0, 0), orientation: Orientation.Horizontal));

            board.Fire(Coordinates.From(x: 0, y: 0));
            board.Fire(Coordinates.From(x: 1, y: 0));
            board.Fire(Coordinates.From(x: 2, y: 0));

            return board;
        }

        private static IBoard boardWithTwoFailedShots()
        {
            var board = BoardMother.Random(SizeMother.Random(width: 10, height:2));
            board.Fire(Coordinates.From(x: 0, y: 0));
            board.Fire(Coordinates.From(x: 0, y: 1));
            return board;
        }

        private static IBoard BoardWithTwoHitShots()
        {
            var board = BoardMother.Random(SizeMother.Random(width: 10, height: 10));

            var initialPositionShip = Coordinates.From(0, 0);
            board.PlaceShip(ShipMother.Random(lenght: 2, position: initialPositionShip));

            var initialPositionOtherShip = Coordinates.From(5, 5);
            board.PlaceShip(ShipMother.Random(lenght: 2, position: initialPositionOtherShip));

            board.Fire(initialPositionShip);
            board.Fire(initialPositionOtherShip);

            return board;
        }

        private static IEnumerable<(IBoard board, List<string> strOutputs)> TestCasesForEmptyBoards()
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

        private static IEnumerable<(IBoard board, string outputStr)> TestCasesForPrintMisses()
        {
            var board_0 = BoardMother.Random(size: SizeMother.Random(width: 10));
            yield return (board_0, " Misses: 0");

            var board_1 = BoardMother.Random(size: SizeMother.Random(width: 10));
            board_1.Fire(Coordinates.From(0, 0));
            yield return (board_1, " Misses: 1");

            var board_2 =  BoardMother.Random(size: SizeMother.Random(width: 10));
            board_2.Fire(Coordinates.From(0, 0));
            board_2.Fire(Coordinates.From(1, 0));
            yield return (board_2, " Misses: 2");
        }
        private static IEnumerable<(IBoard board, string outputStr)> TestCasesForPrintHits()
        {
            var board_0 = CreateEmptyBoard();
            yield return (board_0, " Hits: 0");

            var board_1 = CreateEmptyBoard();
            board_1.Fire(Coordinates.From(0, 0));
            yield return (board_1, " Hits: 1");

            var board_2 = CreateEmptyBoard();
            board_2.Fire(Coordinates.From(0, 0));
            board_2.Fire(Coordinates.From(1, 0));
            yield return (board_2, " Hits: 2");

            var board_3 = CreateEmptyBoard();
            board_3.Fire(Coordinates.From(0, 0));
            board_3.Fire(Coordinates.From(1, 0));
            board_3.Fire(Coordinates.From(0, 1));
            yield return (board_3, " Hits: 3");

            static IBoard CreateEmptyBoard()
            {
                var board = BoardMother.Random(size: SizeMother.Random(width: 10, height:2));
                board.PlaceShip(ShipMother.Random(lenght: 3, orientation: Orientation.Horizontal, position: Coordinates.From(0, 0)));
                board.PlaceShip(ShipMother.Random(lenght: 1, position: Coordinates.From(0, 1)));
                return board;
            }
        }

        private static IEnumerable<(IBoard board, string outputStr)> TestCasesForPrintTotalShots()
        {
            yield return (BoardMother.Random(), " Total shots: 0");

            yield return (boardWithTwoFailedShots(), " Total shots: 2");

            yield return (BoardWithTwoHitShots(), " Total shots: 2");

            yield return (BoardWithThreeSunkedShots(), " Total shots: 3");
        }
    }
}
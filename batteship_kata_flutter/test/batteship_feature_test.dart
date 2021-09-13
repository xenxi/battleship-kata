import 'package:batteship_kata_flutter/domain/ships.dart';
import 'package:batteship_kata_flutter/presentation/board_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter_test/flutter_test.dart';

void main() {
  group('batteship should', () {
    testWidgets('print reporting', (WidgetTester tester) async {
      await aGivenBoard(tester);

      await whenPlayGame(tester);

      expect(find.text('o'), findsNWidgets(15));
      expect(find.text('X'), findsNWidgets(6));
      expect(find.text('g'), findsNWidgets(1));
      expect(find.text('d'), findsNWidgets(2));
      expect(find.text('c'), findsNWidgets(3));
      expect(find.text('x'), findsNWidgets(2));
    });
  });
}

Future<void> aGivenBoard(WidgetTester tester) async {
  final board = BoardWidget(ships: [
    Destroyer(x: 2, y: 3, direction: Direction.vertical),
    Gunship(x: 9, y: 9),
    Gunship(x: 7, y: 2),
    Gunship(x: 2, y: 3),
  ]);

  final app = MaterialApp(
    home: Scaffold(body: board),
  );

  await tester.pumpWidget(app);
}

Future<void> whenPlayGame(WidgetTester tester) async {
  final cells = List.generate(
      10, (index) => List<String>.filled(10, '', growable: false));
  cells[0][2] = 'o';

  cells[1][1] = 'o';
  cells[1][3] = 'o';

  cells[2][1] = 'o';
  cells[2][7] = 'X';

  cells[3][2] = 'X';
  cells[3][3] = 'X';
  cells[3][4] = 'X';

  cells[4][1] = 'o';
  cells[4][6] = 'g';
  cells[4][8] = 'c';

  cells[5][1] = 'o';
  cells[5][2] = 'o';
  cells[5][5] = 'o';
  cells[5][8] = 'c';

  cells[6][3] = 'o';
  cells[6][6] = 'o';
  cells[6][8] = 'c';

  cells[7][1] = 'x';
  cells[7][5] = 'd';
  cells[7][8] = 'X';

  cells[8][2] = 'o';
  cells[8][3] = 'o';
  cells[8][5] = 'd';
  cells[8][8] = 'o';

  cells[9][4] = 'o';
  cells[9][5] = 'x';
  cells[9][6] = 'o';
  cells[9][9] = 'X';

  for (var row = 0; row < 10; row++) {
    for (var col = 0; col < 10; col++) {
      if (cells[row][col].isNotEmpty) {
        await tester.tap(find.byKey(Key('x:$col;y:$row')));
      }
    }
  }
}

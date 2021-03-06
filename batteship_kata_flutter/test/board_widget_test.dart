import 'dart:ui';

import 'package:batteship_kata_flutter/presentation/board_widget.dart';
import 'package:batteship_kata_flutter/presentation/cell_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter_test/flutter_test.dart';

void main() {
  group('board widget should', () {
    final createAppWith = (BoardWidget board) => MaterialApp(
          home: Scaffold(body: board),
        );
    group('draw board with size', () {
      final sizes = <Size>[
        Size(10, 10),
        Size(5, 10),
      ];
      sizes.forEach((size) {
        testWidgets('height: ${size.height} width: ${size.width}',
            (WidgetTester tester) async {
          final aGivenBoard = createAppWith(BoardWidget(
            size: size,
            ships: [],
          ));

          await tester.pumpWidget(aGivenBoard);

          final expectedNumberOfCells = (size.width * size.height).round();
          expect(find.byType(CellWidget), findsNWidgets(expectedNumberOfCells));
        });
      });
    });

    testWidgets('draw all cells with correct keys',
        (WidgetTester tester) async {
      var aGivenBoarSize = Size(2, 2);
      final aGivenBoard = createAppWith(BoardWidget(
        size: aGivenBoarSize,
        ships: [],
      ));

      await tester.pumpWidget(aGivenBoard);

      for (var row = 0; row < aGivenBoarSize.height; row++) {
        for (var col = 0; col < aGivenBoarSize.width; col++) {
          expect(find.byKey(Key('x:$col;y:$row')), findsOneWidget);
        }
      }
    });
  });
}

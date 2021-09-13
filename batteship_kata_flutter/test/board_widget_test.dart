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
  });
}

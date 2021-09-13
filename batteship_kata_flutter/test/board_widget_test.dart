import 'dart:ui';

import 'package:batteship_kata_flutter/presentation/board_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter_test/flutter_test.dart';

void main() {
  group('board widget should', () {
    final app = (BoardWidget board) => MaterialApp(
          home: Scaffold(body: board),
        );
    group('draw board with size', () {
      final sizes = <Size>[
        Size(10, 10),
      ];
      sizes.forEach((size) {
        test('height: ${size.height} width: ${size.width}',
            (WidgetTester tester) async {
          await tester.pumpWidget(app(BoardWidget(
            size: size,
            ships: [],
          )));
        });
      });
    });
  });
}

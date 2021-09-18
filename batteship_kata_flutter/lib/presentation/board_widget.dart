import 'package:batteship_kata_flutter/presentation/cell_widget.dart';
import 'package:flutter/material.dart';

import 'package:batteship_kata_flutter/domain/ships.dart';

class BoardWidget extends StatelessWidget {
  final Size size;
  final List<Ship> ships;
  const BoardWidget({
    Key? key,
    required this.size,
    required this.ships,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Column(
        children: [..._buildCells(context)],
      ),
    );
  }

  List<Widget> _buildCells(BuildContext context) {
    final cells = <Widget>[];

    for (var row = 0; row < size.height; row++) {
      for (var col = 0; col < size.width; col++) {
        cells.add(CellWidget(
          key: Key('x:$col;y:$row'),
        ));
      }
    }

    return cells;
  }
}

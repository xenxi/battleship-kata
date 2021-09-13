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
    final numOfCells = size.height * size.width;

    final cells = <Widget>[];

    for (var i = 0; i < numOfCells; i++) {
      cells.add(CellWidget());
    }

    return cells;
  }
}

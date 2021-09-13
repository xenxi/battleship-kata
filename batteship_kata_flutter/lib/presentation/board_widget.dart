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
      child: null,
    );
  }
}

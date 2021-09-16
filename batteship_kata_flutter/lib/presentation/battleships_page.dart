import 'package:batteship_kata_flutter/presentation/board_widget.dart';
import 'package:flutter/material.dart';

class BattleshipsPage extends StatelessWidget {
  const BattleshipsPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Battleships Kata'),
      ),
      body: BoardWidget(
        size: Size(10, 10),
        ships: [],
      ),
    );
  }
}

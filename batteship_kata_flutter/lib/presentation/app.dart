import 'package:flutter/material.dart';

import 'battleships_page.dart';

class App extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Batteship Kata',
      home: BattleshipsPage(),
    );
  }
}

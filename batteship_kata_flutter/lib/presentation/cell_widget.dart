import 'package:flutter/material.dart';

class CellWidget extends StatelessWidget {
  const CellWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 100,
      width: 100,
      decoration: BoxDecoration(color: Colors.blue, border: Border.all()),
      child: null,
    );
  }
}

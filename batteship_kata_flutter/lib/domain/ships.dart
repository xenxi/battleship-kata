abstract class Ship {
  final int x;
  final int y;
  final Direction direction;
  final int size;

  Ship(
    this.x,
    this.y,
    this.direction,
    this.size,
  );
}

class Gunship extends Ship {
  Gunship({required int x, required int y})
      : super(x, y, Direction.horizontal, 1);
}

class Destroyer extends Ship {
  Destroyer({required int x, required int y, required Direction direction})
      : super(x, y, direction, 3);
}

enum Direction { vertical, horizontal }

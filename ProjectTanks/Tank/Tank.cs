using Field;
using Shared;

namespace Tank
{
    internal enum Direction // Для отслеживания направления движений (нужно для оружия)
    {
        Up,
        Down,
        Left,
        Right
    }

    internal class Tank : IEntity, ConsoleInput.IArrowListener
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private int _speed = 2; // Скорость в две клетки
        private Direction _direction = Direction.Up; // Дефолтное напраление

        public Tank(int startX, int startY)
        {
            X = startX; Y = startY;
        }

        public void Update(float deltaTime)
        {

        }

        public void Draw(ConsoleRenderer renderer) // Отрисовка танка
        {
            renderer.SetPixel(X, Y, '╔', 1);
            renderer.SetPixel(X, Y + 1, '╚', 1);
            renderer.SetPixel(X + 1, Y, '╗', 1);
            renderer.SetPixel(X + 1, Y + 1, '╝', 1);

            switch (_direction) // Поворот оружия
            {
                case Direction.Up:
                    renderer.SetPixel(X, Y, '╬', 1);
                    renderer.SetPixel(X + 1, Y, '╬', 1);
                    renderer.SetPixel(X + 1, Y + 1, '╝', 1);
                    renderer.SetPixel(X, Y + 1, '╚', 1);
                    break;
                case Direction.Down:
                    renderer.SetPixel(X, Y, '╔', 1);
                    renderer.SetPixel(X + 1, Y, '╗', 1);
                    renderer.SetPixel(X + 1, Y + 1, '╬', 1);
                    renderer.SetPixel(X, Y + 1, '╬', 1);
                    break;
                case Direction.Left:
                    renderer.SetPixel(X, Y, '╦', 1);
                    renderer.SetPixel(X + 1, Y, '╗', 1);
                    renderer.SetPixel(X + 1, Y + 1, '╝', 1);
                    renderer.SetPixel(X, Y + 1, '╩', 1);
                    break;
                case Direction.Right:
                    renderer.SetPixel(X, Y, '╔', 1);
                    renderer.SetPixel(X + 1, Y, '╦', 1);
                    renderer.SetPixel(X + 1, Y + 1, '╩', 1);
                    renderer.SetPixel(X, Y + 1, '╚', 1);
                    break;
            }
        }

        //Обработка движения
        public void OnArrowUp(GameField field)
        {
            _direction = Direction.Up;

            if (field.GetCell(X / 2, Y / 2 - 1) == CellType.Empty)
                    Y = Math.Max(1, Y - _speed);
        }
        public void OnArrowDown(GameField field)
        {
            _direction = Direction.Down;

            if (field.GetCell(X / 2, Y / 2 + 1) == CellType.Empty)
                    Y = Math.Min(Console.WindowHeight - 3, Y + _speed);
        }
        public void OnArrowLeft(GameField field)
        {
            _direction = Direction.Left;

            if (field.GetCell(X / 2 - 1, Y / 2) == CellType.Empty)
                    X = Math.Max(1, X - _speed);
        }
        public void OnArrowRight(GameField field)
        {
            _direction = Direction.Right;

            if (field.GetCell(X / 2 + 1, Y / 2) == CellType.Empty)
                    X = Math.Min(Console.WindowWidth - 3, X + _speed);
        }
    }
}

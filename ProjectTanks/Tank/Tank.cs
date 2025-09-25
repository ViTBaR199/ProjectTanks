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
        public void OnArrowUp()
        {
            _direction = Direction.Up;
            Y = Math.Max(1, Y - _speed);
        }
        public void OnArrowDown()
        {
            _direction = Direction.Down;
            Y = Math.Min(Console.WindowHeight - 3, Y + _speed);
        }
        public void OnArrowLeft()
        {
            _direction = Direction.Left;
            X = Math.Max(1, X - _speed);
        }
        public void OnArrowRight()
        {
            _direction = Direction.Right;
            X = Math.Min(Console.WindowWidth - 3, X + _speed);
        }
    }
}

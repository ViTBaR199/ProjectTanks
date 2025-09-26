using Field;
using Share;
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

    internal abstract class Tank : IEntity
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public Direction _direction { get; protected set; } = Direction.Up; // Дефолтное напраление
        public byte _color { get; protected set; }

        protected int _speed = 2; // Скорость в две клетки
        protected float _moveCooldown = 0.2f; // Задержка между шагами
        protected float _moveTimer = 0f;
        protected EntityManager _entityManager;

        // Добавить переменные со скоростью стрельбы
        // и др.

        public Tank(int startX, int startY, EntityManager manager)
        {
            X = startX; Y = startY;
            _entityManager = manager;
        }

        public virtual void Update(float deltaTime)
        {
            if (_moveTimer > 0f)
                _moveTimer -= deltaTime;
        }

        public virtual void Draw(ConsoleRenderer renderer) // Отрисовка танка
        {
            renderer.SetPixel(X, Y, '╔', _color);
            renderer.SetPixel(X, Y + 1, '╚', _color);
            renderer.SetPixel(X + 1, Y, '╗', _color);
            renderer.SetPixel(X + 1, Y + 1, '╝', _color);

            switch (_direction) // Поворот оружия
            {
                case Direction.Up:
                    renderer.SetPixel(X, Y, '╬', _color);
                    renderer.SetPixel(X + 1, Y, '╬', _color);
                    renderer.SetPixel(X + 1, Y + 1, '╝', _color);
                    renderer.SetPixel(X, Y + 1, '╚', _color);
                    break;
                case Direction.Down:
                    renderer.SetPixel(X, Y, '╔', _color);
                    renderer.SetPixel(X + 1, Y, '╗', _color);
                    renderer.SetPixel(X + 1, Y + 1, '╬', _color);
                    renderer.SetPixel(X, Y + 1, '╬', _color);
                    break;
                case Direction.Left:
                    renderer.SetPixel(X, Y, '╦', _color);
                    renderer.SetPixel(X + 1, Y, '╗', _color);
                    renderer.SetPixel(X + 1, Y + 1, '╝', _color);
                    renderer.SetPixel(X, Y + 1, '╩', _color);
                    break;
                case Direction.Right:
                    renderer.SetPixel(X, Y, '╔', _color);
                    renderer.SetPixel(X + 1, Y, '╦', _color);
                    renderer.SetPixel(X + 1, Y + 1, '╩', _color);
                    renderer.SetPixel(X, Y + 1, '╚', _color);
                    break;
            }
        }

        protected bool CanMove(Direction dir, GameField field)
        {
            int newX = X;
            int newY = Y;

            switch (dir)
            {
                case Direction.Up:
                    newY -= _speed;
                    break;
                case Direction.Down:
                    newY += _speed;
                    break;
                case Direction.Left:
                    newX -= _speed;
                    break;
                case Direction.Right:
                    newX += _speed;
                    break;
            }

            int cellX = newX / 2;
            int cellY = newY / 2;

            if (field.GetCell(cellX, cellY) != CellType.Empty)
                return false;

            if (_entityManager.IsCellBlocked(cellX, cellY, this))
                return false;

            return true;
        }

        protected void Move(Direction dir, GameField field)
        {
            _direction = dir;

            if (CanMove(dir, field))
            {
                switch (dir)
                {
                    case Direction.Up:
                        Y -= _speed;
                        break;
                    case Direction.Down:
                        Y += _speed;
                        break;
                    case Direction.Left:
                        X -= _speed;
                        break;
                    case Direction.Right:
                        X += _speed;
                        break;
                }
            }
        }
    }
}

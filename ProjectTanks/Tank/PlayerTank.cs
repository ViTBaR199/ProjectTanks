using Field;
using Share;
using Shared;

namespace Tank
{
    internal class PlayerTank : Tank, ConsoleInput.IArrowListener
    {
        public PlayerTank(int startX, int startY, EntityManager manager) : base(startX, startY, manager)
        {
            this._color = 1;
        }

        //Обработка движения
        public void OnArrowUp(GameField field) => TryMove(Direction.Up, field);
        public void OnArrowDown(GameField field) => TryMove(Direction.Down, field);
        public void OnArrowLeft(GameField field) => TryMove(Direction.Left, field);
        public void OnArrowRight(GameField field) => TryMove(Direction.Right, field);

        private void TryMove(Direction direction, GameField field)
        {
            if (_moveTimer <= 0f)
            {
                Move(direction, field);
                _moveTimer = _moveCooldown;
            }
        }
    }
}

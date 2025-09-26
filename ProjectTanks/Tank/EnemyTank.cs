using Field;
using Share;

namespace Tank
{
    internal class EnemyTank : Tank
    {
        private readonly Random _rand = new();
        private float _changeDirTimer = 0f;

        public EnemyTank(int startX, int startY, EntityManager manager) : base(startX, startY, manager)
        {
            this._color = 3;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            _changeDirTimer -= deltaTime;
        }

        public void MoveRandomly(GameField field)
        {
            if (_changeDirTimer <= 0f)
            {
                List<Direction> availableDir = new List<Direction>();

                foreach (Direction dir in Enum.GetValues(typeof(Direction)))
                {
                    if (CanMove(dir, field))
                        availableDir.Add(dir);
                }

                if (availableDir.Count > 0)
                    _direction = availableDir[_rand.Next(availableDir.Count)];

                _changeDirTimer = 1f;
            }

            if (_moveTimer <= 0f)
            {
                Move(_direction, field);
                _moveTimer = _moveCooldown;
            }
        }
    }
}

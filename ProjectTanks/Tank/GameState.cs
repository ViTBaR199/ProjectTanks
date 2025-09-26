using Field;
using share;
using Share;
using Shared;


namespace Tank
{
    internal class GameState : BaseGameState
    {
        private readonly EntityManager _entityManager = new EntityManager();
        private readonly PlayerTank _playerTank; // Танк игрока
        private readonly EnemyTank _enemyTank; // Вражеский танк
        private readonly ConsoleInput _input; // Управление
        private readonly GameField _field;

        public GameState(ConsoleInput input)
        {
            _input = input;

            var levelManager = new LevelManager();
            _field = levelManager.GenerateLevel(21, 15);

            for (int y = 0; y < _field.Height; y++)
            {
                for (int x = 0; x < _field.Width; x++)
                {
                    if (_field.GetCell(x, y) == CellType.Wall)
                    {
                        _entityManager.AddEntity(new WallEntity(x, y));
                    }
                }
            }

            _playerTank = new PlayerTank(2, 2, _entityManager);
            _enemyTank = new EnemyTank(_field.Width - 1, _field.Height - 1, _entityManager);

            _input.Subscribe(_playerTank);

            _entityManager.AddEntity(_playerTank);
            _entityManager.AddEntity(_enemyTank);
        }

        

        public override void Update(float deltaTIme)
        {
            _input.Update(_field);
            _playerTank.Update(deltaTIme);
            _enemyTank.Update(deltaTIme);
            _enemyTank.MoveRandomly(_field);
        }

        public override void Draw(ConsoleRenderer renderer)
        {
            renderer.Clear();
            _field.Draw(renderer); // Отрисовка окружения
            _entityManager.Draw(renderer); // Отрисовка сущностей
        }

        public override void Reset()
        {

        }

        public override bool IsDone() => false;
    }
}

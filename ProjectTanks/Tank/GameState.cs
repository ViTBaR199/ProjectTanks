using Field;
using Share;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank
{
    internal class GameState : BaseGameState
    {
        private readonly EntityManager _entityManager = new EntityManager();
        private readonly Tank _playerTank; // Танк игрока
        private readonly ConsoleInput _input; // Управление
        private readonly GameField _field;

        public GameState(ConsoleInput input)
        {
            _input = input;

            var levelManager = new LevelManager();
            _field = levelManager.GenerateLevel(21, 15);

            _playerTank = new Tank(2, 2);
            _input.Subscribe(_playerTank);

            _entityManager.AddEntity(_playerTank);
        }

        public override void Update(float deltaTIme)
        {
            _input.Update();
            _playerTank.Update(deltaTIme);
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

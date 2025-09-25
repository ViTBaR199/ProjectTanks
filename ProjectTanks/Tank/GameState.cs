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
        private readonly Tank _playerTank;
        private readonly ConsoleInput _input;

        public GameState(ConsoleInput input)
        {
            _playerTank = new Tank(10, 10);
            _input = input;
            _input.Subscribe(_playerTank);
        }

        public override void Update(float deltaTIme)
        {
            _input.Update();
            _playerTank.Update(deltaTIme);
        }

        public override void Draw(ConsoleRenderer renderer)
        {
            renderer.Clear();
            _playerTank.Draw(renderer);
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }

        public override bool IsDone() => false;
    }
}

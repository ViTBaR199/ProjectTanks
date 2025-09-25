using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share
{
    internal class EntityManager
    {
        private readonly List<IEntity> _entities = new List<IEntity>();

        public void AddEntity(IEntity entity)
        {
            _entities.Add(entity);
        }

        public void Update(float deltaTime)
        {
            foreach (var entity in _entities)
            {
                entity.Update(deltaTime);
            }
        }

        public void Draw(ConsoleRenderer renderer)
        {
            foreach (var entity in _entities)
            {
                entity.Draw(renderer);
            }
        }
    }
}

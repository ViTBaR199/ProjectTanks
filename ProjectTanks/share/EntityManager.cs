using share;
using Shared;
using Tank;

namespace Share
{
    internal class EntityManager // Класс сущностей
    {
        private readonly List<IEntity> _entities = new List<IEntity>(); // Хранение всех сущностей

        public void AddEntity(IEntity entity) => _entities.Add(entity);

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

        public bool IsCellBlocked(int cellX, int cellY, IEntity self)
        {
            foreach (var e in _entities)
            {
                if (e == self) continue;

                if (e is Tank.Tank t)
                {
                    int tx = t.X / 2;
                    int ty = t.Y / 2;
                    if (tx == cellX && ty == cellY)
                        return true;
                }

                if (e is WallEntity w)
                {
                    if (w.X == cellX && w.Y == cellY)
                        return true;
                }
            }
            return false;
        }
    }
}

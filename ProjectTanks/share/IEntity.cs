namespace Shared
{
    internal interface IEntity // Интерфейс сущности
    {
        int X { get; }
        int Y { get; }

        void Update(float deltaTime);
        void Draw(ConsoleRenderer renderer);
    }
}

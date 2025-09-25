namespace Shared
{
    internal interface IEntity
    {
        int X { get; }
        int Y { get; }

        void Update(float deltaTime);
        void Draw(ConsoleRenderer renderer);
    }
}

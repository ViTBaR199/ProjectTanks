namespace Shared
{
    internal abstract class BaseGameState
    {
        public abstract void Update(float deltaTIme);
        public abstract void Reset();
        public abstract void Draw(ConsoleRenderer renderer);
        public abstract bool IsDone();
    }
}

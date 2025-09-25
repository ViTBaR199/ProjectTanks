using Shared;

namespace Tank
{
    internal class Tank : IEntity, ConsoleInput.IArrowListener
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private int _speed = 2;

        public Tank(int startX, int startY)
        {
            X = startX; Y = startY;
        }

        public void Update(float deltaTime)
        {

        }

        public void Draw(ConsoleRenderer renderer)
        {
            renderer.SetPixel(X, Y, '╔', 1);
            renderer.SetPixel(X, Y + 1, '╚', 1);
            renderer.SetPixel(X + 1, Y, '╗', 1);
            renderer.SetPixel(X + 1, Y + 1, '╝', 1);
        }

        public void OnArrowUp() => Y = Math.Max(0, Y - _speed);
        public void OnArrowDown() => Y = Math.Min(Console.WindowHeight - 2, Y + _speed);
        public void OnArrowLeft() => X = Math.Max(1, X - _speed);
        public void OnArrowRight() => X = Math.Min(Console.WindowWidth - 2, X + _speed);
    }
}

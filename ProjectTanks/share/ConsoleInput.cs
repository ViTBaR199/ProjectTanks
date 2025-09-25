using Field;

namespace Shared
{
    internal class ConsoleInput
    {
        public interface IArrowListener
        {
            void OnArrowDown(GameField field);
            void OnArrowUp(GameField field);
            void OnArrowLeft(GameField field);
            void OnArrowRight(GameField field);
        }

        private readonly HashSet<IArrowListener> _arrowListeners = new HashSet<IArrowListener>();

        public void Subscribe(IArrowListener arrowListener)
        {
            _arrowListeners.Add(arrowListener);
        }

        public void Update(GameField field)
        {
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow or ConsoleKey.W:
                        foreach (var arrowListener in _arrowListeners) arrowListener.OnArrowUp(field);
                        break;
                    case ConsoleKey.DownArrow or ConsoleKey.S:
                        foreach (var arrowListener in _arrowListeners) arrowListener.OnArrowDown(field);
                        break;
                    case ConsoleKey.RightArrow or ConsoleKey.D:
                        foreach (var arrowListener in _arrowListeners) arrowListener.OnArrowRight(field);
                        break;
                    case ConsoleKey.LeftArrow or ConsoleKey.A:
                        foreach (var arrowListener in _arrowListeners) arrowListener.OnArrowLeft(field);
                        break;
                }
            }
        }
    }
}

namespace Shared
{
    internal class ConsoleInput
    {
        public interface IArrowListener
        {
            void OnArrowDown();
            void OnArrowUp();
            void OnArrowLeft();
            void OnArrowRight();
        }

        private readonly HashSet<IArrowListener> _arrowListeners = new HashSet<IArrowListener>();

        public void Subscribe(IArrowListener arrowListener)
        {
            _arrowListeners.Add(arrowListener);
        }

        public void Update()
        {
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow or ConsoleKey.W:
                        foreach (var arrowListener in _arrowListeners) arrowListener.OnArrowUp();
                        break;
                    case ConsoleKey.DownArrow or ConsoleKey.S:
                        foreach (var arrowListener in _arrowListeners) arrowListener.OnArrowDown();
                        break;
                    case ConsoleKey.RightArrow or ConsoleKey.D:
                        foreach (var arrowListener in _arrowListeners) arrowListener.OnArrowRight();
                        break;
                    case ConsoleKey.LeftArrow or ConsoleKey.A:
                        foreach (var arrowListener in _arrowListeners) arrowListener.OnArrowLeft();
                        break;
                }
            }
        }
    }
}

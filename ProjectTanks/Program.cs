using Shared;
using Tank;

internal class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var colors = new[] { ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.Yellow };
        var renderer = new ConsoleRenderer(colors);
        var input = new ConsoleInput();

        var state = new GameState(input);

        var sw = new System.Diagnostics.Stopwatch();
        sw.Start();

        while (true)
        {
            float deltaTime = (float)sw.Elapsed.TotalSeconds;
            sw.Restart();

            state.Update(deltaTime);
            state.Draw(renderer);
            renderer.Render();

            System.Threading.Thread.Sleep(16);
        }
    }
}
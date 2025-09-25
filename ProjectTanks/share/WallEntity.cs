using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share
{
    internal class WallEntity : IEntity
    {
        public int X { get; }
        public int Y { get; }

        public WallEntity(int x, int y)
        {
            X = x; Y = y;
        }

        public void Update(float deltaTime) { }

        public void Draw(ConsoleRenderer renderer)
        {
            renderer.SetPixel(X * 2, Y * 2, '▓', 2);
            renderer.SetPixel(X * 2 + 1, Y * 2, '▓', 2);
            renderer.SetPixel(X * 2, Y * 2 + 1, '▓', 2);
            renderer.SetPixel(X * 2 + 1, Y * 2 + 1, '▓', 2);
        }
    }
}

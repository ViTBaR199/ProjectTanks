using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Field
{
    enum CellType
    {
        Empty, // можно проехать
        Wall, // стена
        Water // вода
    }

    internal class GameField
    {
        public int Width;
        public int Height;

        private CellType[,] _cells;

        public GameField(int width, int height)
        {
            Width = width;
            Height = height;
            _cells = new CellType[Width, Height];

            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    _cells[x, y] = CellType.Wall;
        }

        public void SetCell(int x, int y, CellType cellType)
        {
            _cells[x, y] = cellType;
        }

        public CellType GetCell(int x, int y)
        {
            return _cells[x, y];
        }

        public void Draw(ConsoleRenderer renderer)
        {
            for (int y = 0; y <  Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var cell = _cells[x, y];

                    int drawX = x * 2;
                    int drawY = y * 2;

                    if (drawX < 0 || drawY < 0)
                        continue;

                    if (cell == CellType.Wall)
                    {
                        if (drawX < renderer.width && drawY < renderer.height) renderer.SetPixel(drawX, drawY, '▓', 1);
                        if (drawX + 1 < renderer.width && drawY < renderer.height) renderer.SetPixel(drawX + 1, drawY, '▓', 1);
                        if (drawX < renderer.width && drawY + 1 < renderer.height) renderer.SetPixel(drawX, drawY + 1, '▓', 1);
                        if (drawX + 1 < renderer.width && drawY + 1 < renderer.height) renderer.SetPixel(drawX + 1, drawY + 1, '▓', 1);
                    }
                    else if (cell == CellType.Water)
                    {
                        if (drawX < renderer.width && drawY < renderer.height) renderer.SetPixel(drawX, drawY, '≈', 2);
                        if (drawX + 1 < renderer.width && drawY < renderer.height) renderer.SetPixel(drawX + 1, drawY, '≈', 2);
                        if (drawX < renderer.width && drawY + 1 < renderer.height) renderer.SetPixel(drawX, drawY + 1, '≈', 2);
                        if (drawX + 1 < renderer.width && drawY + 1 < renderer.height) renderer.SetPixel(drawX + 1, drawY + 1, '≈', 2);
                    }
                }
            }
        }
    }
}

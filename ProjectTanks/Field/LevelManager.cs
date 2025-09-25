using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Field
{
    internal class LevelManager
    {
        private readonly Random _rand = new Random();

        public GameField GenerateLevel(int width, int height)
        {
            // Гарантируем нечётные размеры
            if (width < 3) width = 3;
            if (height < 3) height = 3;
            if (width % 2 == 0) width++;
            if (height % 2 == 0) height++;

            var field = new GameField(width, height);

            EllerAlgorithm(field);

            return field;
        }

        // Алгоритм Эллера по созданию лабиринта
        private void EllerAlgorithm(GameField field)
        {
            int W = field.Width;
            int H = field.Height;

            int cols = (W - 1) / 2;   // количество логических колонок
            int rows = (H - 1) / 2;   // количество логических строк

            var set = new int[cols];
            int nextSetId = 1;

            for (int r = 0; r < rows; r++)
            {
                int y = 1 + 2 * r; // физическая координата строки центров

                // 1) присваивание id множеств для клеток этой строки (если нет)
                for (int i = 0; i < cols; i++)
                {
                    if (set[i] == 0)
                        set[i] = nextSetId++;
                    int cellX = 1 + 2 * i;
                    field.SetCell(cellX, y, CellType.Empty); // вырез центра клетки
                }

                // 2) случайное создание горизонтальных проходов между соседними клетками и объединие множеств
                for (int i = 0; i < cols - 1; i++)
                {
                    if (set[i] != set[i + 1] && (_rand.Next(2) == 0 || r == rows - 1))
                    {
                        // прорез стенки между i и i+1
                        int betweenX = 1 + 2 * i + 1; // чётная координата между центрами
                        field.SetCell(betweenX, y, CellType.Empty);

                        int oldSet = set[i + 1];
                        int newSet = set[i];

                        // слив множества
                        for (int k = 0; k < cols; k++)
                            if (set[k] == oldSet)
                                set[k] = newSet;
                    }
                }

                // 3) для последней строки вертикальные проходы не делаются
                if (r == rows - 1)
                    break;

                // 4) создаём вертикальные проходы
                var nextSet = new int[cols]; // множества следующей строки
                var groups = new Dictionary<int, List<int>>();
                for (int i = 0; i < cols; i++)
                {
                    if (!groups.TryGetValue(set[i], out var list))
                    {
                        list = new List<int>();
                        groups[set[i]] = list;
                    }
                    list.Add(i);
                }

                foreach (var kv in groups)
                {
                    var indices = kv.Value;
                    var chosen = new List<int>();

                    // каждый элемент множества получает вертикальное соединение с вероятностью 50%
                    foreach (var idx in indices)
                    {
                        if (_rand.Next(2) == 0)
                            chosen.Add(idx);
                    }

                    // минимум один вертикальный проход
                    if (chosen.Count == 0)
                        chosen.Add(indices[_rand.Next(indices.Count)]);

                    // прорезаем вертикали и переносим множества вниз
                    foreach (var idx in chosen)
                    {
                        int cellX = 1 + 2 * idx;
                        int belowY = y + 1; // чётная координата между текущей и следующей центровой строкой
                        field.SetCell(cellX, belowY, CellType.Empty);
                        nextSet[idx] = set[idx]; // перенос id множества в следующую строку
                    }
                }

                // переход к следующей строке с наследуемыми множествами
                set = nextSet;
            }
        }
    }
}
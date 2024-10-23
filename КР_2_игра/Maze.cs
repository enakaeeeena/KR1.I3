using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Кр
{
    public class Maze
    {
        private int width;
        private int height;
        private char[,] maze;
        private Random random = new Random();

        public Maze(int width, int height)
        {
            this.width = width;
            this.height = height;
            maze = new char[height, width];
            InitializeMaze();
        }

        private void InitializeMaze()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    maze[y, x] = '#'; // Стена
                }
            }
        }

        public void Generate()
        {
            Stack<(int, int)> stack = new Stack<(int, int)>();
            int startX = random.Next(1, width - 1);
            int startY = random.Next(1, height - 1);
            maze[startY, startX] = ' '; // Путь
            stack.Push((startX, startY));

            while (stack.Count > 0)
            {
                var (x, y) = stack.Pop();
                List<(int, int)> neighbors = GetNeighbors(x, y);

                if (neighbors.Count > 0)
                {
                    stack.Push((x, y)); // Вернуться обратно
                    var (nx, ny) = neighbors[random.Next(neighbors.Count)];
                    maze[ny, nx] = ' '; // Открыть путь
                    maze[(y + ny) / 2, (x + nx) / 2] = ' '; // Открыть стену между

                    stack.Push((nx, ny)); // Перейти к соседу
                }
            }
        }

        private List<(int, int)> GetNeighbors(int x, int y)
        {
            List<(int, int)> neighbors = new List<(int, int)>();

            if (x > 1 && maze[y, x - 2] == '#') neighbors.Add((x - 2, y));
            if (x < width - 2 && maze[y, x + 2] == '#') neighbors.Add((x + 2, y));
            if (y > 1 && maze[y - 2, x] == '#') neighbors.Add((x, y - 2));
            if (y < height - 2 && maze[y + 2, x] == '#') neighbors.Add((x, y + 2));

            return neighbors;
        }

        public void Display()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(maze[y, x]);
                }
                Console.WriteLine();
            }
        }

        public bool IsWalkable(int x, int y)
        {
            return maze[y, x] == ' ';
        }
    }
}



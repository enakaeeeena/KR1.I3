using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Кр
{
    public class Player
    {
        private Maze maze;
        private int playerX;
        private int playerY;

        public Player(Maze maze)
        {
            this.maze = maze;
            playerX = 1; 
            playerY = 1;
        }

        public void Move()
        {
            while (true)
            {
                Console.Clear();
                maze.Display();
                Console.WriteLine("Используйте W (вверх), A (влево), S (вниз), D (вправо) для перемещения. Нажмите Q для выхода.");

                var key = Console.ReadKey(true).Key;
                int newX = playerX, newY = playerY;

                switch (key)
                {
                    case ConsoleKey.W: newY--; break;
                    case ConsoleKey.A: newX--; break;
                    case ConsoleKey.S: newY++; break;
                    case ConsoleKey.D: newX++; break;
                    case ConsoleKey.Q: return;
                }

                if (maze.IsWalkable(newX, newY))
                {
                    playerX = newX;
                    playerY = newY;
                }
            }
        }
    }
}

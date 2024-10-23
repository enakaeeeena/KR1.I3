using System;
using Кр;

public class Program
{
    static void Main(string[] args)
    {
        Maze maze = new Maze(10, 10);
        maze.Generate();
        maze.Display();

        Player player = new Player(maze);
        player.Move();
    }
}

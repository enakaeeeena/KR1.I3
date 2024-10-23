using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOfLife : MonoBehaviour
{
  
    public int gridSizeX = 20;
    public int gridSizeY = 20;

    public enum CellState { Dead, Alive }

  
    private CellState[,] grid;

 
    void Start()
    {
        grid = new CellState[gridSizeX, gridSizeY];
        InitializeGrid();
    }

    void InitializeGrid()
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                grid[x, y] = Random.value > 0.4f ? CellState.Alive : CellState.Dead;
            }
        }
    }

    // Правила
    void Update()
    {
        CellState[,] newGrid = new CellState[gridSizeX, gridSizeY];
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                int aliveNeighbors = CountAliveNeighbors(x, y);
                if (grid[x, y] == CellState.Alive)
                {
                    if (aliveNeighbors < 2 || aliveNeighbors > 3)
                    {
                        newGrid[x, y] = CellState.Dead;
                    }
                    else
                    {
                        newGrid[x, y] = CellState.Alive;
                    }
                }
                else
                {
                    if (aliveNeighbors == 3)
                    {
                        newGrid[x, y] = CellState.Alive;
                    }
                    else
                    {
                        newGrid[x, y] = CellState.Dead;
                    }
                }
            }
        }
        grid = newGrid;
        DrawGrid();
    }

 
    int CountAliveNeighbors(int x, int y)
    {
        int count = 0;
        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                int nx = x + dx;
                int ny = y + dy;
                if (nx >= 0 && nx < gridSizeX && ny >= 0 && ny < gridSizeY)
                {
                    if (grid[nx, ny] == CellState.Alive)
                    {
                        count++;
                    }
                }
            }
        }
        if (grid[x, y] == CellState.Alive)
        {
            count--;
        }
        return count;
    }

    // Поле
    void DrawGrid()
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                if (grid[x, y] == CellState.Alive)
                {
                    GameObject cell = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cell.transform.position = new Vector3(x, y, 0);
                    cell.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkProcGen : MonoBehaviour
{
    [SerializeField] private GameObject RoomPrefab;
    [SerializeField] private int GridWidth = 5;
    [SerializeField] private int GridHeight = 5;
    [SerializeField] private float RoomOffset = 1.0f;
    [SerializeField] private int walkLength = 10;  // The number of steps before potentially stopping a path

    private bool[,] visited;
    private List<Vector2Int> directions = new List<Vector2Int>
    {
        new Vector2Int(0, 1),   // Up
        new Vector2Int(0, -1),  // Down
        new Vector2Int(1, 0),   // Right
        new Vector2Int(-1, 0)   // Left
    };

    void Start()
    {
        GenerateMaze();
    }

    void GenerateMaze()
    {
        visited = new bool[GridWidth, GridHeight];
        // Start generating the maze from the top-left corner (0,0)
        GenerateRandomPaths(0, 0);
    }

    void GenerateRandomPaths(int startX, int startY)
    {
        visited[startX, startY] = true;
        Vector2Int currentPos = new Vector2Int(startX, startY);
        int steps = 0;

        while (steps < walkLength)
        {
            directions.Shuffle();
            bool moved = false;

            foreach (var dir in directions)
            {
                int newX = currentPos.x + dir.x;
                int newY = currentPos.y + dir.y;

                // Ensure the new position is within grid bounds and not visited
                if (newX >= 0 && newX < GridWidth && newY >= 0 && newY < GridHeight && !visited[newX, newY])
                {
                    // Place the room at the current position
                    Vector3 roomPosition = new Vector3(currentPos.x * RoomOffset, 0, currentPos.y * RoomOffset);
                    Instantiate(RoomPrefab, roomPosition, Quaternion.identity);

                    // Mark the new cell as visited and move there
                    visited[newX, newY] = true;
                    currentPos = new Vector2Int(newX, newY);
                    moved = true;
                    steps++;
                    break;  // Break after moving in one direction
                }
            }

            // If no movement was made, the path has hit a dead end
            if (!moved)
            {
                break;  // Exit the loop if no valid moves are available
            }
        }
    }
}

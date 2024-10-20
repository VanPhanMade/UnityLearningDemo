using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeProcGen : MonoBehaviour
{
    [SerializeField] private GameObject RoomPrefab;
    [SerializeField] private int GridWidth = 5;
    [SerializeField] private int GridHeight = 5;
    [SerializeField] private float RoomOffset = 1.0f;

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
        GenerateMazeRecursive(0, 0);
    }

    void GenerateMazeRecursive(int x, int y)
    {
        // Mark the current cell as visited
        visited[x, y] = true;

        // Shuffle the directions to create a random maze
        directions.Shuffle();

        // Use a copy of the list to iterate over it
        List<Vector2Int> directionsCopy = new List<Vector2Int>(directions);

        foreach (var dir in directionsCopy)
        {
            int newX = x + dir.x;
            int newY = y + dir.y;

            // Ensure the new position is within grid bounds and unvisited
            if (newX >= 0 && newX < GridWidth && newY >= 0 && newY < GridHeight && !visited[newX, newY])
            {
                // Place the room at the current position
                Vector3 roomPosition = new Vector3(x * RoomOffset, 0, y * RoomOffset);
                Instantiate(RoomPrefab, roomPosition, Quaternion.identity);

                // Recursively generate the maze from the new position
                GenerateMazeRecursive(newX, newY);
            }
        }
    }

}

public static class ListExtensions
{
    // Helper function to shuffle a list (Fisher-Yates shuffle)
    public static void Shuffle<T>(this IList<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randIndex = Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[randIndex];
            list[randIndex] = temp;
        }
    }
}

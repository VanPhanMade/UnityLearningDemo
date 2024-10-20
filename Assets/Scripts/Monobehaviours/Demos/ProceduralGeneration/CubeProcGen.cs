using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeProcGen : MonoBehaviour
{
    [SerializeField] private List<GameObject> CubeTypes;
    [SerializeField] private int GridWidth = 5;
    [SerializeField] private int GridHeight = 5;

    [SerializeField] private float CubeOffset = 1.0f;
    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        // Loop through grid dimensions
        for (int x = 0; x < GridWidth; x++)
        {
            for (int z = 0; z < GridHeight; z++)
            {
                // Randomly select a cube type
                GameObject selectedCube = CubeTypes[Random.Range(0, CubeTypes.Count)];

                // Calculate the position with an offset
                Vector3 spawnPosition = new Vector3(x * CubeOffset, 0, z * CubeOffset);

                // Instantiate the selected cube type at the calculated position
                Instantiate(selectedCube, spawnPosition, Quaternion.identity);
            }
        }
    }
}

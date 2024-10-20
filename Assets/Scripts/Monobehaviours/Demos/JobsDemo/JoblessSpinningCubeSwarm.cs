using UnityEngine;
using System.Diagnostics;

public class JoblessSpinningCubeSwarm : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab; // Cube prefab to spawn
    [SerializeField] private int cubeCount = 100;   // Number of cubes
    [SerializeField] private float radius = 5f;     // Radius of circular motion

    private Vector3[] cubePositions;
    private Transform[] cubeTransforms;
    private float time = 0f;

    void Start()
    {
        // Initialize arrays for cube transforms and positions
        cubePositions = new Vector3[cubeCount];
        cubeTransforms = new Transform[cubeCount];

        // Spawn cubes
        for (int i = 0; i < cubeCount; i++)
        {
            Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(-10f, 10f), 0, UnityEngine.Random.Range(-10f, 10f));
            GameObject cube = Instantiate(cubePrefab, spawnPos, Quaternion.identity);
            cubeTransforms[i] = cube.transform;
            cubePositions[i] = cube.transform.position;
        }
    }

    void Update()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        stopwatch.Start();
        // Increment time to animate the circular motion
        time += Time.deltaTime;

        // Calculate cube positions directly on the main thread
        for (int i = 0; i < cubeCount; i++)
        {
            float angle = i + time;
            float x = radius * Mathf.Cos(angle);
            float z = radius * Mathf.Sin(angle);

            // Update the position of each cube
            cubePositions[i] = new Vector3(x, 0, z);
            cubeTransforms[i].position = cubePositions[i];
        }
        stopwatch.Stop();
        UnityEngine.Debug.Log($"{stopwatch.Elapsed.TotalMilliseconds:F2} ms");
    }
}

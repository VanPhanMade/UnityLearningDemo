using UnityEngine;
using Unity.Jobs;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Burst;
using System.Diagnostics;

public class SpinningCubeSwarm : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab; // Cube prefab to spawn
    [SerializeField] private int cubeCount = 100;   // Number of cubes
    [SerializeField] private float radius = 5f;     // Radius of circular motion

    private NativeArray<float3> cubePositions;
    private Transform[] cubeTransforms;
    private float time = 0f;
    void Start()
    {
        // Initialize arrays for cube transforms and positions
        cubePositions = new NativeArray<float3>(cubeCount, Allocator.Persistent);
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

        // Create and schedule the job
        MoveCubesJob moveCubesJob = new MoveCubesJob
        {
            radius = radius,
            time = time,
            cubePositions = cubePositions
        };

        JobHandle jobHandle = moveCubesJob.Schedule(cubeCount, 64);
        jobHandle.Complete();

        // Update cube positions after the job completes
        for (int i = 0; i < cubeCount; i++)
        {
            cubeTransforms[i].position = cubePositions[i];
        }
        stopwatch.Stop();
        UnityEngine.Debug.Log($"{stopwatch.Elapsed.TotalMilliseconds:F2} ms");
    }

    private void OnDestroy()
    {
        // Dispose of the native array when the object is destroyed
        if (cubePositions.IsCreated)
            cubePositions.Dispose();
    }

    // Define the job to move cubes in a circular motion
    [BurstCompile]
    struct MoveCubesJob : IJobParallelFor
    {
        public float radius;
        public float time;
        public NativeArray<float3> cubePositions;

        public void Execute(int index)
        {
            float angle = index + time;
            float x = radius * math.cos(angle);
            float z = radius * math.sin(angle);

            // Update the position of each cube
            cubePositions[index] = new float3(x, 0, z);
        }
    }
}

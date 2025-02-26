using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // List of obstacle prefabs
    public float spawnInterval = 2f; // Time interval between spawns
    public float minHeight = -2f; // Minimum height for obstacle spawn
    public float maxHeight = 2f;  // Maximum height for obstacle spawn
    public float obstacleSpeed = 5f; // Speed at which the obstacles move to the left
    public Transform playerTransform; // Reference to the player's transform to determine when to spawn obstacles

    private Queue<GameObject> obstaclePool = new Queue<GameObject>(); // Pool of reusable obstacles

    void Start()
    {
        // Start spawning obstacles at regular intervals
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            // Choose a random obstacle prefab
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            // Get an obstacle from the pool or instantiate a new one if the pool is empty
            GameObject obstacle = GetObstacleFromPool(obstaclePrefab);

            // Set random height for obstacle spawn
            float randomHeight = Random.Range(minHeight, maxHeight);
            obstacle.transform.position = new Vector3(playerTransform.position.x + 20f, randomHeight, 0); // Spawns slightly off-screen to the right

            // Set the obstacle's speed (moving left)
            obstacle.GetComponent<Obstacle>().SetSpeed(obstacleSpeed);

            // Wait for the next spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    
    void Update()
    {
        foreach (GameObject obstacle in obstaclePool)
        {
            if (obstacle.activeSelf && obstacle.transform.position.x < playerTransform.position.x - 20f)
            {
                ReturnObstacleToPool(obstacle);
            }
        }
    }
    
    // Get an obstacle from the pool, or instantiate a new one if the pool is empty
    private int maxPoolSize = 20; // Maximum number of objects in the pool

    GameObject GetObstacleFromPool(GameObject obstaclePrefab)
    {
        if (obstaclePool.Count > 0)
        {
            GameObject obstacle = obstaclePool.Dequeue();
            obstacle.SetActive(true);
            return obstacle;
        }
        else if (obstaclePool.Count < maxPoolSize)
        {
            // Instantiate a new obstacle if the pool is empty and hasn't reached max size
            return Instantiate(obstaclePrefab);
        }
        else
        {
            // If the pool is full, you can either return null, or just reuse an object from the pool.
            // Or handle this case differently.
            return null;
        }
    }


    // Add obstacle back to pool once it's off-screen
    public void ReturnObstacleToPool(GameObject obstacle)
    {
        obstacle.SetActive(false);
        obstaclePool.Enqueue(obstacle);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public GameObject missilePrefab; // List of obstacle prefabs
    public float spawnInterval = 2f; // Time interval between spawns
    public Transform playerTransform; // Reference to the player's transform to determine when to spawn obstacles

    private Queue<GameObject> missilePool = new Queue<GameObject>(); // Pool of reusable obstacles

    void Start()
    {
        // Start spawning obstacles at regular intervals
        StartCoroutine(SpawnMissiles());
    }

    IEnumerator SpawnMissiles()
    {
        while (true)
        {
            // Get an obstacle from the pool or instantiate a new one if the pool is empty
            GameObject missile = GetMissileFromPool(missilePrefab);
            
            missile.transform.position = new Vector3(playerTransform.position.x + 20f, 0, 0); // Spawns slightly off-screen to the right

            // Wait for the next spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    
    void Update()
    {
        foreach (GameObject missile in missilePool)
        {
            if (missile.activeSelf && missile.transform.position.x < playerTransform.position.x - 20f)
            {
                ReturnObstacleToPool(missile);
            }
        }
    }
    
    // Get an obstacle from the pool, or instantiate a new one if the pool is empty
    private int maxPoolSize = 20; // Maximum number of objects in the pool

    GameObject GetMissileFromPool(GameObject missilePrefab)
    {
        if (missilePool.Count > 0)
        {
            GameObject missile = missilePool.Dequeue();
            missile.SetActive(true);
            return missile;
        }
        else if (missilePool.Count < maxPoolSize)
        {
            // Instantiate a new obstacle if the pool is empty and hasn't reached max size
            return Instantiate(missilePrefab);
        }
        else
        {
            // If the pool is full, you can either return null, or just reuse an object from the pool.
            // Or handle this case differently.
            return null;
        }
    }


    // Add obstacle back to pool once it's off-screen
    public void ReturnObstacleToPool(GameObject missile)
    {
        missile.SetActive(false);
        missilePool.Enqueue(missile);
    }
}

using UnityEngine;

public class RandomPrefabSpawner : MonoBehaviour
{
    // List of prefabs to choose from
    public GameObject[] prefabs;

    // Range of time in seconds between spawns
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 5f;

    // Range for the spawn height (y position)
    public float minSpawnHeight = 0f;
    public float maxSpawnHeight = 10f;

    // Base position (x and z values remain constant, only y will vary)
    public Vector3 spawnBasePosition = new Vector3(0, 0, 0);

    private void Start()
    {
        // Start the spawning process
        StartCoroutine(SpawnPrefabAtRandomInterval());
    }

    private System.Collections.IEnumerator SpawnPrefabAtRandomInterval()
    {
        while (true)
        {
            // Wait for a random amount of time between min and max spawn time
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            // Select a random prefab from the list
            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject prefabToSpawn = prefabs[randomIndex];

            // Randomize the spawn height (y position)
            float randomHeight = Random.Range(minSpawnHeight, maxSpawnHeight);

            // Create the final spawn position with the randomized height
            Vector3 spawnPosition = new Vector3(spawnBasePosition.x, randomHeight, spawnBasePosition.z);

            // Instantiate the selected prefab at the defined position
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
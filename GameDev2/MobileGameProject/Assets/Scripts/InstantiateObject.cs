using UnityEngine;
using System.Collections.Generic;

public class InstantiateObject : MonoBehaviour
{
    public GameObject prefab;
    public GameObject spawnPoint;
    
    // Expose the list of prefabs in the Inspector
    public List<GameObject> prefabs;

    // Example method to instantiate a random prefab from the list
    public void InstantiateRandomPrefab()
    {
        if (prefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, prefabs.Count);
            Instantiate(prefabs[randomIndex], spawnPoint.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No prefabs in the list!");
        }
    }
    public void Instantiate()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}

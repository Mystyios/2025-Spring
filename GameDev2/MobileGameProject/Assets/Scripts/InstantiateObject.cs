using UnityEngine;
using System.Collections.Generic;

public class InstantiateObject : MonoBehaviour
{
    public GameObject singlePrefab;
    public List<GameObject> prefabs;
    
    public GameObject singlePrefabSpawnPoint;
    public GameObject multiPrefabSpawnPoint;

    public void InstantiateSinglePrefab()
    {
        Instantiate(singlePrefab, singlePrefabSpawnPoint.transform.position, Quaternion.identity);
    }
    
    // Example method to instantiate a random prefab from the list
    public void InstantiateRandomPrefab()
    {
        if (prefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, prefabs.Count);
            Instantiate(prefabs[randomIndex], multiPrefabSpawnPoint.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No prefabs in the list!");
        }
    }
    
}

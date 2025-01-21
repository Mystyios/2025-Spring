using UnityEngine;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour
{
    public List<GameObject> platformPrefabs; // List of platform prefabs
    public float spawnOffsetX = 10f;  // X position off-screen for the platforms
    public float platformSpeed = 5f;   // Speed at which the platform moves
    public Transform player;           // Reference to the player's transform

    private List<GameObject> activePlatforms; // List of active platforms in the scene
    private Vector3 offScreenPosition; // Position where platforms are placed off-screen
    private int platformIndex = 0; // Index for keeping track of which platform to move

    void Start()
    {
        activePlatforms = new List<GameObject>();
        offScreenPosition = new Vector3(-spawnOffsetX, 0f, 0f); // Set the initial off-screen position

        // Instantiate 2 copies of each platform off-screen at the start of the game
        foreach (var prefab in platformPrefabs)
        {
            for (int i = 0; i < 2; i++) // 2 copies of each platform
            {
                GameObject platform = Instantiate(prefab, offScreenPosition, Quaternion.identity);
                platform.SetActive(false); // Set inactive initially
                activePlatforms.Add(platform);
            }
        }

        // Start the process of moving platforms
        StartCoroutine(MovePlatforms());
    }

    System.Collections.IEnumerator MovePlatforms()
    {
        while (true)
        {
            // Pick the next platform in the list (cycling through)
            GameObject platform = activePlatforms[platformIndex];

            if (!platform.activeInHierarchy)
            {
                // Activate the platform and set its position just off-screen to the right of the player
                platform.SetActive(true);
                platform.transform.position = new Vector3(player.position.x + spawnOffsetX, platform.transform.position.y, platform.transform.position.z);

                // Move the platform from right to left
                while (platform.transform.position.x > player.position.x - spawnOffsetX)
                {
                    platform.transform.Translate(Vector3.left * platformSpeed * Time.deltaTime);
                    yield return null;
                }

                // Once the platform passes the player, return it to its off-screen position
                platform.SetActive(false); // Deactivate the platform
                platform.transform.position = offScreenPosition; // Reset to off-screen
            }

            // Update platform index to cycle through platforms
            platformIndex = (platformIndex + 1) % activePlatforms.Count;

            yield return null; // Wait for the next frame before checking again
        }
    }
}

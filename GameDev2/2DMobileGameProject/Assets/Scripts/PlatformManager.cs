using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;  // Reference to the platform prefab
    public int numberOfPlatforms = 5;  // Number of platforms to spawn
    public float platformSpeed = 5f;   // Speed at which platforms move to the left
    public float platformSpacing = 2f; // Spacing between platforms
    public Vector3 initialPosition = new Vector3(10f, 0f, 0f); // Starting position of platforms

    private GameObject[] platforms; // Array to hold platform references

    void Start()
    {
        platforms = new GameObject[numberOfPlatforms];

        // Instantiate initial platforms
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            Vector3 position = initialPosition + new Vector3(i * platformSpacing, 0, 0);
            platforms[i] = Instantiate(platformPrefab, position, Quaternion.identity);
        }
    }

    void Update()
    {
        // Move all platforms to the left
        foreach (var platform in platforms)
        {
            platform.transform.position -= Vector3.right * platformSpeed * Time.deltaTime;

            // If platform is offscreen, reset its position to the right
            if (platform.transform.position.x < -25f) // You can adjust this value based on your camera's view
            {
                platform.transform.position = new Vector3(initialPosition.x + platformSpacing * (numberOfPlatforms - 1), platform.transform.position.y, platform.transform.position.z);
            }
        }
    }
}
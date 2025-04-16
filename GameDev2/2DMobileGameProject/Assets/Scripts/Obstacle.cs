using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    private float speed;
    public FloatData SpeedData;
    public UnityEvent onPlayerTriggerEnter;

    // Call this function from the spawner to set the obstacle's speed
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Update()
    {
        speed = SpeedData.Value;
        // Move the obstacle to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        
        // Check if the obstacle is off-screen (can adjust based on your screen boundaries)
        if (transform.position.x < -12f) // Adjust this depending on your screen width
        {
            // Once off-screen, return it to the pool (can call the spawner's method)
            ObstacleSpawner spawner = FindObjectOfType<ObstacleSpawner>();
            spawner.ReturnObstacleToPool(gameObject);
        }
    }
    
    // This method will be called when another collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other collider is the player
        if (other.CompareTag("Player"))
        {
            // Invoke the Unity event when the player enters the trigger
            onPlayerTriggerEnter.Invoke();
        }
    }
}
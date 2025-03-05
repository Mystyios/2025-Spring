using UnityEngine;
using UnityEngine.Events;

public class MissileBehavior : MonoBehaviour
{
    public Transform player;  // Reference to the player object
    public float followTime = 2f;  // Time the missile follows the player height (in seconds)
    public float missileSpeed = 5f;  // Speed of the missile when it starts traveling
    private Vector3 startPosition;  // Initial position of the missile
    private bool isFollowingPlayer = true;  // Flag to check if the missile is following the player
    private float followTimer = 0f;  // Timer to track the time spent following the player
    public UnityEvent onPlayerTriggerEnter;

    void Start()
    {
        startPosition = transform.position;  // Store the initial position of the missile
    }

    void Update()
    {
        if (isFollowingPlayer)
        {
            // Follow the player's height (y-position)
            transform.position = new Vector3(startPosition.x, player.position.y, startPosition.z);

            // Increment the timer
            followTimer += Time.deltaTime;

            // After 2 seconds, stop following the player and move to the left
            if (followTimer >= followTime)
            {
                isFollowingPlayer = false;
            }
        }
        else
        {
            // Move the missile to the left across the screen
            transform.Translate(Vector3.left * missileSpeed * Time.deltaTime);
        }
    }
    
    // This method will be called when another collider enters the trigger zone
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other collider is the player
        if (other.CompareTag("Player"))
        {
            // Invoke the Unity event when the player enters the trigger
            onPlayerTriggerEnter.Invoke();
        }
    }
}

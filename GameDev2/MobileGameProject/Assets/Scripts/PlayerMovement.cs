using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed at which the player moves
    public float jumpForce = 10f; // Force applied when jumping
    public float gravityMultiplier = 2f; // Multiplier to increase gravity for the player
    public int jumpCount = 2;
    private Rigidbody rb;         // Reference to the player's Rigidbody

    private bool isGrounded;      // To check if the player is grounded

    void Start()
    {
        // Get the Rigidbody component attached to the player
        rb = GetComponent<Rigidbody>();
    }

    /*
    void Update()
    {
        // Make the player move constantly to the right
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        // Check for mouse click or screen touch to trigger jump
        if ((Input.GetMouseButtonDown(0) && isGrounded) || (Input.GetMouseButtonDown(0) && jumpCount > 0))
        {
            jumpCount--;
            Jump();
        }
    }
    */
    public void Jump()
    {
        if (jumpCount > 0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount--;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // Check if the player is on the ground by detecting collision with ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            //isGrounded = true;
            jumpCount = 2;
        }
    }

    /*
    void OnCollisionExit(Collision collision)
    {
        // If the player leaves the ground, it's no longer grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
*/
    void FixedUpdate()
    {
        // Apply custom gravity multiplier
        if (rb != null)
        {
            // Apply extra gravity to simulate a stronger fall
            rb.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
        }
    }
}
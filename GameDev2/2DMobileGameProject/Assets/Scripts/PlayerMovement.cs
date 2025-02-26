using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float initialBoostForce = 10f; // Initial boost force
    public float steadyUpwardSpeed = 2f; // Speed when holding
    public float fallSpeed = 5f; // Fall speed
    public float topLimit = 5f; // Top Y position limit (max height)
    public float gravityScaleWhenFalling = 1f; // Gravity scale when falling
    public float gravityScaleWhenMovingUp = 0.1f; // Lower gravity scale when moving up

    private Rigidbody2D rb;
    private bool isHolding = false;
    private bool isTapping = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Initial upward boost when the screen is first tapped
                if (transform.position.y < topLimit)
                {
                    rb.velocity = Vector2.up * initialBoostForce;
                    isTapping = true;
                    rb.gravityScale = gravityScaleWhenMovingUp;  // Enable upward movement with low gravity
                }
            }
            else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // Keep moving upward at a steady pace while the screen is being held
                if (transform.position.y < topLimit)
                {
                    rb.velocity = new Vector2(0f, steadyUpwardSpeed);
                    rb.gravityScale = gravityScaleWhenMovingUp; // Keep gravity low when moving up
                }
                isHolding = true;
            }
        }
        else
        {
            // When there is no input, apply falling gravity if not on the ground
            if (!isHolding)
            {
                rb.gravityScale = gravityScaleWhenFalling;
                rb.velocity = new Vector2(0f, -fallSpeed);
            }

            isHolding = false;
            isTapping = false;
        }

        // Prevent the player from exceeding the top limit
        if (transform.position.y >= topLimit)
        {
            rb.velocity = Vector2.zero;
            transform.position = new Vector2(transform.position.x, topLimit);
            rb.gravityScale = gravityScaleWhenFalling; // Reset gravity after reaching top
        }
    }
}

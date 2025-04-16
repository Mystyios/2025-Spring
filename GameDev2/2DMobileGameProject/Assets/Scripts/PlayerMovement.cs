using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public float initialBoostForce = 10f; // Initial boost force
    public float steadyUpwardSpeed = 2f; // Speed when holding
    public float fallSpeed = 5f; // Fall speed
    public float topLimit = 5f; // Top Y position limit (max height)
    public float gravityScaleWhenFalling = 1f; // Gravity scale when falling
    public float gravityScaleWhenMovingUp = 0.1f; // Lower gravity scale when moving up
    public UnityEvent onTouch, releaseTouch;

    private Rigidbody rb;
    private bool isHolding = false;
    private bool isTapping = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.touchCount > 0)
        {
            onTouch.Invoke();
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (transform.position.y < topLimit)
                {
                    rb.velocity = Vector3.up * initialBoostForce;
                    isTapping = true;
                    rb.useGravity = true;
                    Physics.gravity = new Vector3(0f, -9.81f * gravityScaleWhenMovingUp, 0f);
                }
            }
            else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                if (transform.position.y < topLimit)
                {
                    rb.velocity = new Vector3(0f, steadyUpwardSpeed, 0f);
                    Physics.gravity = new Vector3(0f, -9.81f * gravityScaleWhenMovingUp, 0f);
                }
                isHolding = true;
            }
        }
        else
        {
            if (!isHolding)
            {
                releaseTouch.Invoke();
                Physics.gravity = new Vector3(0f, -9.81f * gravityScaleWhenFalling, 0f);
                rb.velocity = new Vector3(0f, -fallSpeed, 0f);
            }

            isHolding = false;
            isTapping = false;
        }

        // Prevent the player from exceeding the top limit
        if (transform.position.y >= topLimit)
        {
            rb.velocity = Vector3.zero;
            transform.position = new Vector3(transform.position.x, topLimit, transform.position.z);
            Physics.gravity = new Vector3(0f, -9.81f * gravityScaleWhenFalling, 0f);
        }
    }
}

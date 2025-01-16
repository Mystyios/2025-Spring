using UnityEngine;

public class FallingObject : MonoBehaviour
{
    // You can modify this to change the gravity effect, but Unity handles gravity automatically
    public float gravityScale = 1f;

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to this object
        rb = GetComponent<Rigidbody>();
        
        // Make sure the object has a Rigidbody to apply gravity
        if (rb == null)
        {
            Debug.LogError("No Rigidbody attached to this object.");
        }
    }

    void Update()
    {
        // Apply additional gravity scale if needed, Unity will apply gravity automatically based on Rigidbody settings.
        if (rb != null)
        {
            rb.AddForce(Vector3.down * gravityScale, ForceMode.Acceleration);
        }
    }
}
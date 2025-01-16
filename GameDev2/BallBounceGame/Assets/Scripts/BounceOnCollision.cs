using UnityEngine;

public class BounceOnCollision : MonoBehaviour
{
    // The force with which the object will bounce when hit
    public float bounceForce = 10f;

    // Optionally, you can add some random variation to the bounce direction
    public float randomBounceVariation = 5f;

    // This method is called when a collision happens
    private void OnCollisionEnter(Collision collision)
    {
        // Get the Rigidbody of the object that hit this one
        Rigidbody hitObjectRb = collision.gameObject.GetComponent<Rigidbody>();

        // If the object that collided has a Rigidbody (i.e., it's a physical object)
        if (hitObjectRb != null)
        {
            // Calculate the bounce direction, we apply a force in the opposite direction
            Vector3 bounceDirection = collision.contacts[0].normal; // Normal of the contact point
            bounceDirection = -bounceDirection; // Bounce away from the surface hit

            // Apply the bounce force with some random variation to the direction
            Vector3 randomBounce = bounceDirection + new Vector3(
                Random.Range(-randomBounceVariation, randomBounceVariation),
                randomBounceVariation, // Ensure some vertical bounce
                Random.Range(-randomBounceVariation, randomBounceVariation)
            );

            // Apply force to the colliding object
            hitObjectRb.AddForce(randomBounce * bounceForce, ForceMode.Impulse);
        }
    }
}
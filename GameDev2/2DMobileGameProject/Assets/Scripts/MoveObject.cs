using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public FloatData floatData;
    public bool reverseDirection = false;
    private float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        if (reverseDirection)
        {
            moveSpeed = floatData.Value;
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            moveSpeed = floatData.Value;
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }
}

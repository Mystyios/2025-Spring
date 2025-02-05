using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public IntData intData;
    private float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        moveSpeed = intData.Value;
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
}

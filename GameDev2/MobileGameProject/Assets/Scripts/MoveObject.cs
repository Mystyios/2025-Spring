using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public IntData intData;
    public float moveSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        moveSpeed = intData.Value;
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
}

using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    public GameObject prefab;

    public void Instantiate()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}

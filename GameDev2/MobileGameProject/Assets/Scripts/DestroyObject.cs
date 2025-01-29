using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public string destroyObjectTag;
    public bool checkTag;

    private void OnTriggerEnter(Collider other)
    {
        if (checkTag && other.gameObject.CompareTag(destroyObjectTag))
        {
            Destroy(gameObject);
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}

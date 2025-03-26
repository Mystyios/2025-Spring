using UnityEngine;
using UnityEngine.Events;

public class SimpleTriggerEventBehavior : MonoBehaviour
{
    public UnityEvent OnTriggerEnterEvent;
    public string ObjectTag;
    public bool checkTag = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (checkTag)
        {
            if (other.CompareTag(ObjectTag))
            {
                OnTriggerEnterEvent.Invoke();
            }
            else
            {
                return;
            }
        }
        else
        {
            OnTriggerEnterEvent.Invoke();
        }
        
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class SimpleCoroutineBehaviour : MonoBehaviour
{
    public float seconds = 1;
    private WaitForSeconds _waitForSeconds;
    public UnityEvent @event;
    private Coroutine coroutine;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(seconds);
        StartCoroutine();
    }

    private IEnumerator SimpleCoroutine()
    {
        while (true)
        {
            yield return _waitForSeconds;
            @event.Invoke();
        }
    }

    public void StartCoroutine()
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(SimpleCoroutine());
        }
    }

    public void StopCoroutine()
    {
        if (coroutine != null)
        {
            StopCoroutine(SimpleCoroutine());
            coroutine = null;
        }
    }
}

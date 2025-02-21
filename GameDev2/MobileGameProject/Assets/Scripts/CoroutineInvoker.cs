using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class CoroutineInvoker : MonoBehaviour
{
    // The UnityEvent to invoke
    public UnityEvent onInvoke;

    // The minimum delay time (in seconds) for randomization
    public float minDelayTime = 0.5f;

    // The maximum delay time (in seconds) for randomization
    public float maxDelayTime = 2f;

    // A flag to control whether the delay should be randomized
    public bool useRandomDelay = true;
    
    public bool startOnAwake = false;

    // A reference to the Coroutine
    private Coroutine invokeCoroutine;

    private void Awake()
    {
        if (startOnAwake)
        {
            StartInvoking();
        }
    }

    // Start the coroutine
    public void StartInvoking()
    {
        if (invokeCoroutine == null)
        {
            invokeCoroutine = StartCoroutine(InvokeRepeatedly());
        }
    }

    // Stop the coroutine
    public void StopInvoking()
    {
        if (invokeCoroutine != null)
        {
            StopCoroutine(invokeCoroutine);
            invokeCoroutine = null;
        }
    }

    // The coroutine that invokes the UnityEvent repeatedly
    private IEnumerator InvokeRepeatedly()
    {
        while (true)
        {
            // Invoke the UnityEvent
            onInvoke.Invoke();

            // Determine the delay (randomized if needed)
            float delay = useRandomDelay ? Random.Range(minDelayTime, maxDelayTime) : minDelayTime;

            // Wait for the specified delay time before invoking again
            yield return new WaitForSeconds(delay);
        }
    }
}
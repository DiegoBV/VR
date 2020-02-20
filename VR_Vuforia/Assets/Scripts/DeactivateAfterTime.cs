using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAfterTime : MonoBehaviour
{
    [Tooltip("Time to deactivate the gameObject that this is attached to")]
    public float timeToDeactivate;

    private float currentTime = 0.0f;

    private void OnEnable()
    {
        currentTime = 0.0f;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= timeToDeactivate)
        {
            gameObject.SetActive(false);
            currentTime = 0.0f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Tooltip("Rotation speed at Z")]
    public float zspeed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, Mathf.Sin(Time.time * zspeed)));
    }
}

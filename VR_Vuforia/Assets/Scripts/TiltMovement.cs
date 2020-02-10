using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class TiltMovement : MonoBehaviour
{
    public float speed;

    public Camera cam;

    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 movement = new Vector3(Input.acceleration.x, 0.0f, 0.0f);
        rigidBody.velocity = movement * speed;
    }
}

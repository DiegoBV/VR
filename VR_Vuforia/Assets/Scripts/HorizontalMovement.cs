using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class HorizontalMovement : MonoBehaviour
{
    [Tooltip("Speed in the X axis")]
    public float speed;

    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnEnable()
    {
        rigidBody.velocity = new Vector2(0.0f, speed);
    }
}

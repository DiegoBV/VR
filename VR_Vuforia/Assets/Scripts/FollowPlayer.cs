using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class FollowPlayer : MonoBehaviour
{
    [Tooltip("Speed in the X axis")]
    public float speed;

    private Rigidbody2D rigidBody;
    private GameObject target;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.bodyType = RigidbodyType2D.Kinematic;
        target = GameManager.instance.GetPlayer();
    }

    private void Update()
    {
        FollowTarget();      
    }

    private void FollowTarget()
    {
        Vector3 nPosition = SteeringBehaviours.Follow(transform.position, target.transform.position, speed);

        gameObject.transform.position = nPosition;
    }
}

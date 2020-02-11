using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class FollowPlayer : MonoBehaviour
{
    [Tooltip("Min speed")]
    public float minSpeed;

    [Tooltip("Max speed")]
    public float maxSpeed;

    private Rigidbody2D rigidBody;
    private GameObject target;
    private float currentSpeed;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        // rigidBody.bodyType = RigidbodyType2D.Kinematic;
        target = GameManager.instance.GetPlayer();
    }

    private void OnEnable()
    {
        currentSpeed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        FollowTarget();      
    }

    private void FollowTarget()
    {
        Vector3 nPosition = SteeringBehaviours.Follow(transform.position, target.transform.position, currentSpeed);

        gameObject.transform.position = nPosition;
    }
}

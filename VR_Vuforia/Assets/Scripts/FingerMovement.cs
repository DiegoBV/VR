using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class FingerMovement : MonoBehaviour
{
    [Tooltip("Speed of the input follow")]
    public float speed;
    [Tooltip("Offset with destination")]
    public float offset = 0.5f;

    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            FollowInput();
        }
    }

    private void FollowInput()
    {
#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)
        Vector3 destPosition = GameManager.instance.GetCamera().ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, transform.position.z));
#else
        Vector3 destPosition = GameManager.instance.GetCamera().ScreenToWorldPoint(Input.mousePosition);
#endif
        Vector3 nPosition = SteeringBehaviours.Follow(transform.position, destPosition, speed);

        if(Vector3.Distance(nPosition, destPosition) > offset)
            gameObject.transform.position = nPosition;
    }
}

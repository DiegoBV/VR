using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour
{
    [Tooltip("Bullet speed")]
    public float speed;
    [Tooltip("Time to be deactivated in seconds")]
    public float timeToDie = 4.0f;

    private Rigidbody2D rigidBody;
    private float currentTime;

    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > timeToDie)
        {
            currentTime = 0;
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        currentTime = 0;
    }

    public void SetTargetPosition(Vector3 position)
    {
        Vector3 director = position - transform.position;
        director.Normalize();

        rigidBody.velocity = director * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health h = collision.gameObject.GetComponent<Health>();
        if(h != null)
        {
            h.ReduceHealth();
            gameObject.SetActive(false);
        }
    }
}

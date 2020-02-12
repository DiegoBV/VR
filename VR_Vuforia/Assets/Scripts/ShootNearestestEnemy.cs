using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootNearestestEnemy : MonoBehaviour
{
    public float radius = 3.0f;
    public GameObjectPool bulletPool;
    public float timeToShoot = 0.2f;

    private float currentTime = 0;
    private GameObject currentEnemy;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D[] collisions = Physics2D.CircleCastAll(transform.position, radius, new Vector2(0.0f, 0.0f));
        Vector3 aux = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);

        foreach(RaycastHit2D col in collisions)
        {
            if (col.collider.gameObject.GetComponent<FollowPlayer>())
            {
                if (Vector3.Distance(transform.position, col.transform.position) < Vector3.Distance(transform.position, aux))
                {
                    aux = col.transform.position;
                    currentEnemy = col.collider.gameObject;
                }
            }
        }

        if (currentEnemy != null && currentTime >= timeToShoot)
        {
            Shoot();
            currentTime = 0;
        }
        currentTime += Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject bullet = bulletPool.GetInactiveGameObject();
        bullet.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        bullet.SetActive(true);
        bullet.GetComponent<Bullet>().SetTargetPosition(currentEnemy.transform.position);
    }
}

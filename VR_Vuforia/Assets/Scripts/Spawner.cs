using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Tooltip("Storage and management of gameObjects")]
    public GameObjectPool gameObjectPool;
    [Tooltip("Waiting time to spawn a gameObject")]
    public float timeToSpawn;
    public GameObject[] spawnPoints;

    private float currentTime = 0;

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= timeToSpawn)
        {
            // spawn
            GameObject go = gameObjectPool.GetInactiveGameObject();
            resetGameObject(go);
            currentTime = 0;
        }
    }

    private void resetGameObject(GameObject go)
    {
        Vector3 spawnPos = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        go.transform.position = new Vector3(spawnPos.x, spawnPos.y, spawnPos.z);
        go.SetActive(true);
    }
}

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
    private int spawns = 0;
    private float _timeToSpawn;

    private void Start()
    {
        _timeToSpawn = timeToSpawn;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= _timeToSpawn)
        {
            // spawn
            GameObject go = gameObjectPool.GetInactiveGameObject();
            resetGameObject(go);
            currentTime = 0;
            spawns++;
            if(spawns % 20 == 0)
            {
                // diff
                if(_timeToSpawn >= 0.5f)
                    _timeToSpawn -= 0.5f;
            }
        }
    }

    private void resetGameObject(GameObject go)
    {
        Vector3 spawnPos = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        go.transform.position = new Vector3(spawnPos.x, spawnPos.y, spawnPos.z);
        go.SetActive(true);
    }
}

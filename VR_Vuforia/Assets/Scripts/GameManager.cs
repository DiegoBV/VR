using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;

    private Camera camera;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        camera = Camera.main;
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public Camera GetCamera()
    {
        return camera;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Tooltip("Player of the game")]
    public GameObject player;
    [Tooltip("Restart game button")]
    public GameObject restartButton;
    [Tooltip("Banan particle system pool")]
    public GameObjectPool bananaSystem;

    private Camera camera;
    private float startingTime;
    private float playingTime;
    private bool gameStopped = false;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        camera = Camera.main;
        startingTime = Time.time;
        restartButton.SetActive(false);
    }

    private void Update()
    {
        playingTime = Time.time - startingTime;   
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
        player.SetActive(false);
        EventManager.GetInstance().TriggerEvent("gameOver");
        gameStopped = true;
        restartButton.SetActive(true);
    }

    public bool IsGameStopped()
    {
        return gameStopped;
    }

    public float GetPlayingTime()
    {
        return playingTime;
    }

    public void Restart()
    {
        restartButton.SetActive(false);
        gameStopped = false;
        player.SetActive(true);
        EventManager.GetInstance().TriggerEvent("restart");
        startingTime = Time.time;
        playingTime = 0;
    }

    public GameObjectPool GetBananaSystem()
    {
        return bananaSystem;
    }
}

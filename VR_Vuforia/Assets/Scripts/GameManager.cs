using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public GameObjectPool bananaSystemPool;
    public GameObject restartButton;
    public AudioClip playerDeath, monkeyDeath;
    public enum Sounds { PlayerDeath, MonkeyDeath};
    
    private Camera _camera;
    private float startingTime;
    private float playingTime;
    private bool gameStopped = false;
    private AudioSource audioSrc;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _camera = Camera.main;
        startingTime = Time.time;
        restartButton.SetActive(false);
        audioSrc = GetComponent<AudioSource>();
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
        return _camera;
    }

    public void GameOver()
    {
        PlaySound(Sounds.PlayerDeath);
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

    public GameObjectPool GetBananaSystemPool()
    {
        return bananaSystemPool;
    }

    public void PlaySound(Sounds sound)
    {
        switch (sound)
        {
            case Sounds.PlayerDeath:
                audioSrc.PlayOneShot(playerDeath);
                break;
            case Sounds.MonkeyDeath:
                audioSrc.PlayOneShot(monkeyDeath);
                break;
            default:
                break;
        }
    }
}

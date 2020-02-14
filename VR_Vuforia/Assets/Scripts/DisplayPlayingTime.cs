using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayingTime : MonoBehaviour
{
    private Text text;
    private int minutes;
    private int seconds;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void OnEnable()
    {
        EventManager.GetInstance().AddListener("restart", Restart);    
    }

    private void OnDisable()
    {
        EventManager.GetInstance().RemoveListener("restart", Restart);
    }

    private void Update()
    {
        if (!GameManager.instance.IsGameStopped())
        {
            FormatTime();
            text.text = "TIME: " + minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    private void FormatTime()
    {
        float currentPlayingTime = GameManager.instance.GetPlayingTime();
        minutes = (int)(currentPlayingTime / 60);
        seconds = (int)(currentPlayingTime % 60);
    }

    private void Restart()
    {
        minutes = seconds = 0;
        text.text = "TIME: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    public TMP_Text timerText;
    public float timerDuration = 60f;
    private float currentTime;
    private bool timerStarted = false;

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            UpdateTimer();
            UpdateUIText();
        }
    }

    void UpdateTimer()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0 && timerStarted == true)
        {
            currentTime = 0;
            //Do stuff when timer reaches 0
            BasketballManager.Instance.BothPlayersFinished();
        }
    }

    void UpdateUIText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        if (!timerStarted)
        {
            timerStarted = true;
            currentTime = timerDuration;
        }  
    }

    public void Player1Finished()
    {
        BasketballManager.Instance.player1Finished = true;
        Debug.Log("Player 1 Finished");
    }
    public void Player2Finished()
    {
        BasketballManager.Instance.player2Finished = true;
        Debug.Log("Player 2 Finished");
    }
}


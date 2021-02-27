using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseCollider : MonoBehaviour
{
    private GameStatus theGameStatus;
    private bool isAutoPlayMode;
    private Ball theBall;
    private const int delayInterval = 2;
    
    private int currentTimer = delayInterval;
    private Text CountDown;
    private void Start()
    {
        // theGameStatus = FindObjectOfType<GameStatus>();
        theGameStatus = GameStatus.gameStatusInstance;
        theBall = FindObjectOfType<Ball>();
        CountDown = GameObject.FindObjectOfType<Text>();
        CountDown.enabled = false;
    }

    private void Update()
    {
        isAutoPlayMode = theGameStatus.IsAutoPlayEnabled();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isAutoPlayMode)
        {
            Debug.Log("cant loose");
            theBall.transform.position = new Vector2(2, 2);
            return;
        }
        Debug.Log("Loose!");
        CountDown.enabled = true;
        StartCoroutine(StartTimerForGameOver());
    }
    
    private IEnumerator StartTimerForGameOver()
    {
        while (currentTimer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currentTimer -= 1;
            CountDown.text = currentTimer.ToString();
        }

        currentTimer = delayInterval;
        SceneManager.LoadScene("Game Over");
    }
}

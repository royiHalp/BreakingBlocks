using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {
    private GameStatus theGameStatus;
    private const int delayInterval = 30;
    private Text CountDown;
    
    private int currentTimer = delayInterval;

    private void Awake()
    {
        if (!theGameStatus)
        {
            theGameStatus = GameStatus.gameStatusInstance;
        }
        if (theGameStatus && theGameStatus.IsAutoPlayEnabled())
        {
            EnableAutoPlayAndStart();
        }
        CountDown = GameObject.FindObjectOfType<Text>();
        if (CountDown)
        {
            CountDown.enabled = false;
        }
    }

    public void EnableAutoPlayAndStart()
    {
        if (!theGameStatus)
        {
            theGameStatus = GameStatus.gameStatusInstance;
        }
        if (theGameStatus)
        {
            theGameStatus.EnableAutoPlay();
        }
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        Scene ActiveScene = SceneManager.GetActiveScene();
        int currentSceneIndex = ActiveScene.buildIndex;
        if (ActiveScene.name == "main game")
        {
            CountDown.enabled = true;
            StartCoroutine(StartTimerForSuccess());
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
    
    private IEnumerator StartTimerForSuccess()
    {
        while (currentTimer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currentTimer -= 1;
            CountDown.text = currentTimer.ToString();
        }

        currentTimer = delayInterval;
        SceneManager.LoadScene("Success");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReloadCurrentScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}

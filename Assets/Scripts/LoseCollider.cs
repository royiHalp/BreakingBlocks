using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private GameStatus theGameStatus;
    private bool isAutoPlayMode;
    private Ball theBall;
    private void Start()
    {
        // theGameStatus = FindObjectOfType<GameStatus>();
        theGameStatus = GameStatus.gameStatusInstance;
        theBall = FindObjectOfType<Ball>();
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
        SceneManager.LoadScene("Game Over");
    }
}

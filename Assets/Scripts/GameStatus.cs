using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    private const float normalGameSpeed = 0.5f;
    [Range(0,1f)] static float gameSpeed = normalGameSpeed;
    public static int lives = 3;

    public static bool isAutoPlayEnabled;

    public static GameStatus gameStatusInstance;
    // Start is called before the first frame update
    void Start()
    {
        gameStatusInstance = this;
    }

    private void Awake()
    {
        GameObject WritingBlocks = GameObject.FindGameObjectWithTag("WritingBlocks");
        if (WritingBlocks)
        {
            float WritingBlocksX = WritingBlocks.transform.position.x;
            float WritingBlocksY = WritingBlocks.transform.position.y;
            WritingBlocks.transform.position =
                new Vector3(WritingBlocksX, WritingBlocksY, 0);            
        }
        else
        {
            Debug.Log("cant find writing blocks");
        }

    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void EnableAutoPlay()
    {
        gameSpeed = 10f;
        isAutoPlayEnabled = true;
    }
    public void DisableAutoPlay()
    {
        gameSpeed = normalGameSpeed;
        isAutoPlayEnabled = false;
    }

    public void SetGameSpeed(float speed)
    {
        gameSpeed = speed;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    [Range(0,1f)] [SerializeField] float gameSpeed = 1f;

    [SerializeField] private bool isAutoPlayEnabled;

    public static GameStatus gameStatusInstance;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
        gameStatusInstance = this;
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
        GameStatus gs = FindObjectOfType<GameStatus>();
        gs.gameSpeed = 10f;
        gs.isAutoPlayEnabled = true;

    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    public void SetGameSpeed(float speed)
    {
        gameSpeed = speed;
    }
}

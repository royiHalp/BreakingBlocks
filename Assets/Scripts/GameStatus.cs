using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0,1f)] [SerializeField] float gameSpeed = 1f;

    [SerializeField] private bool isAutoPlayEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
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

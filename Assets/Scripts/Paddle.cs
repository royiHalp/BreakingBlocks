using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenWidthInWorldUnits = 16f;
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;
    // Start is called before the first frame update
    
    // cached references
    private GameStatus theGameStatus;
    private Ball theBall;
    void Start()
    {
        theGameStatus = GameStatus.gameStatusInstance;
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        // Change the paddle position according to the mouse position
        float mousePositionInWorldUnits = Input.mousePosition.x / Screen.width * screenWidthInWorldUnits;
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        
        // dont allow the x position to go beyond minX and maxX
        paddlePosition.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePosition;
    }

    private float GetXPos()
    {
        if (theGameStatus.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        return Input.mousePosition.x / Screen.width * screenWidthInWorldUnits; // mouse position in the world
    }
}

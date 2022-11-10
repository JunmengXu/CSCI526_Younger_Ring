using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//
// < Control for obstacle >
// 
//  < What do you need to set to use obstacle: >
//  1.  obstacleLife        -- default is 3, you can use any int
//  2.  obstacleColorSet    -- all prefabs (B/W/R/G/B) have been set to the correct obstacleColorSet, only change if you want to tweak it
//
public class Obstacle : MonoBehaviour
{
    public TextMeshProUGUI text;

    private SpriteRenderer sprite;

    // select the obstacle's color
    public ColorSet obstacleColorSet;

    private Color ObstacleColor;

    public Player player;

    // F:   obstacle only hitable by certain color
    // T:   obstacle hitablt by any color
    // only change if you want to tweak it
    [SerializeField] private bool allColorObstacle;

    // num of hits to make obstacle disappear, default is 3
    [SerializeField] private int obstacleLife = 3;

    private void Start()
    {
        text.text = obstacleLife.ToString() + " hits";
        if (player == null)
        {
            // find the player in top hierarchy, not the fake player in speed control
            player = GameObject.Find("/Player").GetComponent<Player>();
        }
        
        switch (obstacleColorSet)
        {
            case ColorSet.White:
                ObstacleColor = Color.white;
                break;
            case ColorSet.Black:
                ObstacleColor = Color.black;
                break;
            case ColorSet.Red:
                ObstacleColor = Color.red;
                break;
            case ColorSet.Green:
                ObstacleColor = Color.green;
                break;
            case ColorSet.Blue:
                ObstacleColor = Color.blue;
                break;
            default:
                ObstacleColor = Color.yellow;
                allColorObstacle = true;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // When the player collides with the obstacle, decrement the obstacle life count if color match
        if (col.gameObject.CompareTag("Player"))
        {

            bool isSameColor = (ObstacleColor == player.playerColor.currentColor);
            if (allColorObstacle || isSameColor)
            {
                // Decrement show on the obstacle text
                obstacleLife--;
                text.text = (obstacleLife).ToString() + " hits";

                // obstacle will disappear when it's life is 0 
                if (obstacleLife == 0)
                {
                    text.gameObject.SetActive(false);
                    gameObject.SetActive(false);
                }
            }
        }
    }

    public enum ColorSet
    {
        Black,
        White,
        Red,
        Green,
        Blue,
        Yellow      // for all-color obstacle
    };
}

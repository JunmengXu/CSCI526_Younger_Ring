using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//
// Control for obstacle
//
public class Obstacle : MonoBehaviour
{
    public TextMeshProUGUI text;

    public SpriteRenderer sprite;
    public ColorSet obstacleColorSet;
    private Color ObstacleColor;
    [SerializeField] private Player player;
    [SerializeField] private bool allColorObstacle;

    // num of hit to make obstacle disappear
    [SerializeField] private int obstacleLife = 3;

    private void Start()
    {
        text.text = obstacleLife.ToString() + " hits";
        //ObstacleColor = sprite.color;
        player = GameObject.Find("Player").GetComponent<Player>();
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
        // When the player collides with the obstacle, decrement the obstacle life count
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
        Yellow
    };
}

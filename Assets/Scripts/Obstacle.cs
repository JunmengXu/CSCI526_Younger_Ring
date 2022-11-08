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

    // num of hit to make obstacle disappear
    int obstacleLife = 3;

    private void OnCollisionEnter2D(Collision2D col)
    {
        // When the player collides with the obstacle, decrement the obstacle life count
        if (col.gameObject.CompareTag("Player"))
        {
            // Decrement show on the obstacle text
            obstacleLife--;
            text.text = (obstacleLife).ToString();

            // obstacle will disappear when it's life is 0 
            if (obstacleLife == 0)
            {
                text.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}

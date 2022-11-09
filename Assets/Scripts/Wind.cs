using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public ColorSet windColorSet;
    private Color windColor;
    [SerializeField] private GameObject windSign;
    [SerializeField] private int magnitude;
    [SerializeField] private int angle;
    [SerializeField] private Player player;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AreaEffector2D>().forceAngle = angle;
        switch (windColorSet)
        {
            case ColorSet.White:
                windColor = Color.white;
                windSign.GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case ColorSet.Black:
                windColor = Color.black;
                windSign.GetComponent<SpriteRenderer>().color = Color.black;
                break;
            case ColorSet.Red:
                windColor = Color.red;
                windSign.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case ColorSet.Green:
                windColor = Color.green;
                windSign.GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case ColorSet.Blue:
                windColor = Color.blue;
                windSign.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            default:
                windColor = Color.yellow;
                windSign.GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "Player")
        {
            bool isSameColor = (windColor == player.playerColor.currentColor);
            if (isSameColor)
            {
                gameObject.GetComponent<AreaEffector2D>().forceMagnitude = magnitude;
                //Debug.Log("Wind is on");
            }
            else
            {
                gameObject.GetComponent<AreaEffector2D>().forceMagnitude = 0;
                //Debug.Log("Wind is off");
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticMovement : MonoBehaviour
{
    public Direction movementType;
    
    // Vertical
    private float startHeight;
    
    // Horizontal
    private float startX;
    
    public float speed;
    public float moveRange;
    
    // Start is called before the first frame update
    void Start()
    {
        var position = transform.position;
        switch (movementType)
        {
            case Direction.Horizontal:
                startX = position.x;
                break;
            case Direction.Vertical:
                startHeight = position.y;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 objectPosition = transform.position;
        
        switch (movementType)
        {
            case Direction.Horizontal:
                // Automatically move the tile left and right
                objectPosition.x = Mathf.PingPong(
                    Time.fixedTime * speed,
                    moveRange) + startX;
                break;
            case Direction.Vertical:
                // Automatically move the tile up and down
                objectPosition.y = Mathf.PingPong(
                    Time.fixedTime * speed,
                    moveRange) + startHeight;
                break;
            case Direction.Rotate:
                transform.RotateAround(objectPosition, Vector3.forward, speed * Time.deltaTime);
                break;
        }

        transform.position = objectPosition;
    }
    
    public enum Direction
    {
        Horizontal,
        Vertical,
        Rotate
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHorizontalMovement : MonoBehaviour
{
    private float startX;
    private float endX;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        var position = transform.position;
        startX = position.x;
        endX = position.x + 3;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tilePosition = transform.position;

        // Automatically move the tile up and down
        //
        tilePosition.x = Mathf.PingPong(
            Time.fixedTime * moveSpeed,
            endX - startX) + startX;

        transform.position = tilePosition;
    }
}

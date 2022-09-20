using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticMovement : MonoBehaviour
{
    private float startHeight;
    private float endHeight;
    public float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        var position = transform.position;
        startHeight = position.y;
        endHeight = position.y + 3;
    }

    // Update is called once per frame
    void Update()
    {
        // Automatically move the tile up and down
        transform.position = new Vector2(
            transform.position.x,
            Mathf.PingPong(
                Time.fixedTime * moveSpeed,
                endHeight - startHeight ) + startHeight);
    }
}

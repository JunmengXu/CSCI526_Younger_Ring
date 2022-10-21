using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    private Magnet magnet;
    // Start is called before the first frame update
    void Start()
    {
        var ForceArea = transform.parent.Find("ForceArea");
        magnet = ForceArea.GetComponent<Magnet>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Player player = col.GetComponent<Player>();
            magnet.isHit = true;
            player.velocity = 0.0f;
            player.horizontalVelocity = 0.0f;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            magnet.isHit = true;
            Player player = other.GetComponent<Player>();
            Transform magnetColorObject = transform.parent.Find("Color");
            Color magnetColor = magnetColorObject.GetComponent<SpriteRenderer>().color;
            if (player.playerColor.currentColor != magnetColor && player.isInMagnet)
            {
                player.velocity = 0.0f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            magnet.isHit = false;
        }
    }


    // private void OnTriggerExit2D(Collider2D col)
    // {
    //     Player player = col.GetComponent<Player>();
    //     player.velocity = 0.0f;
    // }
}

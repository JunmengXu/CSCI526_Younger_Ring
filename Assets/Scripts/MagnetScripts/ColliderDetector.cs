using System.Collections;
using System.Collections.Generic;
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
}

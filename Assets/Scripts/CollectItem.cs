using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIController;

public class CollectItem : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider2D;
    //freeze the timer for several seconds
    [SerializeField] private float pauseTime;
    public UITimerController timer;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        //When the player hit the item
        if(other.gameObject.tag == "Player")
        {
            //Make item disappear
            _spriteRenderer.enabled = false;
            //Stop detect collision
            _collider2D.enabled = false;
            timer.pauseTimer();
            //wait for {pauseTime} seconds, then continue the timer
            Invoke(nameof(continueTimer), pauseTime);
        }
    }

    private void continueTimer()
    {
        timer.continueTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

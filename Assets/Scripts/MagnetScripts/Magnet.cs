using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{

    [SerializeField] private float force;
    private float direction = 1.0f;
    
    private Color color;

    public bool isHit;

    // Start is called before the first frame update
    void Start()
    {
        var ColorLayer = transform.parent.Find("Color");
        var sprite = ColorLayer.GetComponent<SpriteRenderer>();
        color = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.isInMagnet = true;
            var sprite = player.GetComponent<SpriteRenderer>();
            if(sprite.color != color){
                direction = -1.0f;
            }else{
                direction = 1.0f;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        //When the player hit the item
        if(other.gameObject.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            var sprite = player.GetComponent<SpriteRenderer>();
            if(sprite.color != color){
                direction = -1.0f;
            }else{
                direction = 1.0f;
            }

            var degree = (transform.eulerAngles.z / 180 * Mathf.PI);
            player.velocity += force * direction * Mathf.Sin(degree) * Time.deltaTime;
            player.horizontalVelocity += force * direction * Mathf.Cos(degree) * Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            Vector2 playerRigidbodyVelocity = player.playerRigidbody.velocity;
            if(isHit){
                player.velocity = 0.0f;
                player.horizontalVelocity = 0.0f;
            }else{
                player.velocity = Mathf.Abs(playerRigidbodyVelocity.y) < Mathf.Abs(player.velocity) ? playerRigidbodyVelocity.y : player.velocity;
                player.horizontalVelocity = Mathf.Abs(playerRigidbodyVelocity.x) < Mathf.Abs(player.horizontalVelocity) ? playerRigidbodyVelocity.x : player.horizontalVelocity;
            }
            player.isInMagnet = false;
            player.isHitByCatapult = true;
            isHit = false;
        }
    }
}

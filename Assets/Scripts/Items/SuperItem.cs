using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Items
{
    public class SuperItem : MonoBehaviour
    {
        public Player player;
        public Colors playerColor;
        public TMP_Text countdownTimerText;
        
        private SpriteRenderer spriteRenderer;
        private Collider2D itemCollider;
        
        private IEnumerator coroutine;
        
        // Make the player invincible for several seconds
        [SerializeField] private float invincibleTime;
        private float effectTimer;
        private bool startCountdown = false;

        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            itemCollider = GetComponent<Collider2D>();

            effectTimer = invincibleTime + 1;
        }

        private void Update()
        {
            if (startCountdown)
            {
                effectTimer -= Time.deltaTime;
                countdownTimerText.text = ((int)effectTimer).ToString();
            }
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            //When the player hit the item
            if(other.gameObject.CompareTag("Player"))
            {
                //Make item disappear
                spriteRenderer.enabled = false;
                //Stop detect collision
                itemCollider.enabled = false;

                // Enter SUPER mode let's go!
                player.isSuperStatus = true;
                // Tell the Colors component to change color and layer accordingly
                playerColor.HandleSuperItemColorAndLayer();
        
                // Handle duration of the item effect
                coroutine = ItemEffect(invincibleTime);
                StartCoroutine(coroutine);
            }
        }

        private IEnumerator ItemEffect(float waitTime)
        {
            startCountdown = true;
            yield return new WaitForSeconds(waitTime);

            // Exit SUPER mode...
            startCountdown = false;
            countdownTimerText.text = "";
            player.isSuperStatus = false;
            playerColor.ExitSuperItemEffect();
        }
    }
}

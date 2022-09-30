using UnityEngine;

namespace ColorAdd
{
    public class Player : MonoBehaviour
    {
        /// <summary>
        /// Player Settings
        /// </summary>
        // Player's jump force
        [SerializeField] private float jumpForce;
        // Gravity will decrease the jumpForce when the player is in air
        [SerializeField] private float gravity;
        // Player's horizontal move speed
        [SerializeField] private float moveSpeed;

        public bool gameover = false;

        /// <summary>
        /// Player's Motion Status
        /// </summary>
        [SerializeField] private bool isGrounded = false;

        /// <summary>
        /// Player Movement Inputs
        /// </summary>
        // Player's vertical velocity
        private float velocity = 0;
        // User's keyboard inputs(Horizontal)
        private float horizontal = 0;

        /// <summary>
        /// Player Attributes
        /// </summary>
        public Colors playerColor;
        public Rigidbody2D playerRigidbody;

        // Number of jumps
        public int jumps = 0;


        void Update()
        {
            // Always listen to keyboard inputs
            horizontal = Input.GetAxisRaw("Horizontal");

            // When the player touches a ground it can land on, jump
            if (isGrounded)
            {
                velocity = jumpForce;
                isGrounded = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            // When the player collides with a ground it can land on, such as floors and tiles
            HandleFloorAndTileCollision(col);

            //HandleColorAddCollision(col);

            // When the player collides with the FinishLine, end the game
            if (col.gameObject.CompareTag("FinishLine"))
            {
                gameover = true;
            }
        }

        //private void HandleColorAddCollision(Collision2D collision)
        //{
        //    if (collision.gameObject.CompareTag("ColorAdd"))
        //    {
        //        playerColor.ChangeColorAndLayer(11);
        //        Debug.Log("==" + collision.gameObject.layer);
        //    }
        //}

        private void HandleFloorAndTileCollision(Collision2D collision)
        {
            // The player can ground itself only when it's not jumping (not going upwards)
            if (velocity <= 0)
            {
                if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Tile"))
                {
                    GroundSelf();
                }
            }
        }

        private void FixedUpdate()
        {
            // Get the current velocity
            Vector2 playerRigidbodyVelocity = playerRigidbody.velocity;

            // Handle horizontal movement, apply a horizontal velocity
            playerRigidbodyVelocity.x = moveSpeed * horizontal;

            // Update player velocity, and handle tile collision
            if (!isGrounded)
            {
                // Update vertical velocity
                playerRigidbodyVelocity.y = velocity;
                // Decrease velocity by applying gravity
                velocity += gravity * Time.fixedDeltaTime;
            }

            playerRigidbody.velocity = playerRigidbodyVelocity;
        }

        private void GroundSelf()
        {
            // Ground self and change a new color, as well as the layer
            isGrounded = true;
            // playerColor.ChangeColorAndLayer();
            // increment num of jumps
            jumps++;
        }
    }
}

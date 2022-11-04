using UnityEngine;

namespace PauseScreenScripts.DifficultySettingScripts
{
    public class FakePlayer : MonoBehaviour
    {
        /// <summary>
        /// Player Settings
        /// </summary>
        // Player's jump force
        [SerializeField] private float jumpForce;
        // Gravity will decrease the jumpForce when the player is in air
        [SerializeField] private float gravity;
        // Player's horizontal move speed
        // [SerializeField] private float moveSpeed;
    
        /// <summary>
        /// Player's Motion Status
        /// </summary>
        [SerializeField] private bool isGrounded = false;
        [SerializeField] private float groundHeight;

        /// <summary>
        /// Player Movement Inputs
        /// </summary>
        // Player's vertical velocity
        public float velocity = 0;
        // User's keyboard inputs(Horizontal)
        // private float horizontal = 0;
    
        /// <summary>
        /// Player Attributes
        /// </summary>
        // Player's SpriteRenderer component
        public SpriteRenderer sprite;

        /// <summary>
        /// Player's color status
        /// </summary>
        public Color currentColor;
        public Color nextColor;

        public PlayerPreference playerPreference;
        
        private void Start()
        {
            // Calculate a fake ground height
            groundHeight = transform.parent.position.y - 2.95f;
            // Get player's current color, and set the next color
            currentColor = sprite.color;
            nextColor = Color.black;
        }

        void Update()
        {
            // Get the current velocity
            Vector3 fakePlayerTransform = transform.position;
            
            // Always listen to keyboard inputs
            // horizontal = Input.GetAxisRaw("Horizontal");

            if (fakePlayerTransform.y <= groundHeight)
            {
                GroundSelf();
            }
        
            // When the player touches a ground it can land on, jump
            if (isGrounded)
            {
                velocity = jumpForce;
                isGrounded = false;
            }

            // Handle horizontal movement, apply a horizontal velocity
            // playerRigidbodyVelocity.x = moveSpeed * horizontal;

            // Update player velocity, and handle tile collision
            if (!isGrounded)
            {
                // fakePlayerTransform.y += velocity * Time.unscaledDeltaTime * playerPreference.scale;
                fakePlayerTransform.y += velocity * Time.unscaledDeltaTime * (PlayerPrefs.HasKey("Scale") ? PlayerPrefs.GetFloat("Scale") : 1f);
                // Decrease velocity by applying gravity
                // velocity += gravity * Time.unscaledDeltaTime * playerPreference.scale;
                velocity += gravity * Time.unscaledDeltaTime * (PlayerPrefs.HasKey("Scale") ? PlayerPrefs.GetFloat("Scale") : 1f);
            }
        
            transform.position = fakePlayerTransform;
        }

        private void GroundSelf()
        {
            // Ground self and change a new color
            isGrounded = true;
            
            sprite.color = nextColor;
            currentColor = sprite.color;

            nextColor = currentColor == Color.black ? Color.white : Color.black;
        }
    }
}

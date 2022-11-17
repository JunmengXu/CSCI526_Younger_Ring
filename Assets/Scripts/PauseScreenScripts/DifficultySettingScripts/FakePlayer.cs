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
        public float moveSpeed;
    
        /// <summary>
        /// Player's Motion Status
        /// </summary>
        [SerializeField] private bool isGrounded = false;
        [SerializeField] private float groundHeight;
        [SerializeField] private float leftWall;
        [SerializeField] private float rightWall;

        /// <summary>
        /// Player Movement Inputs
        /// </summary>
        // Player's vertical velocity
        public float velocity = 0;
        // User's keyboard inputs(Horizontal)
        private float horizontal = 0;
    
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
        
        private void Start()
        {
            // Get the position of the fake stage in the current scene
            // to calculate child position values based on an offset
            Vector3 fakeStagePosition = transform.parent.position;
            // Calculate fake wall positions
            leftWall = fakeStagePosition.x - 6.9f;
            rightWall = fakeStagePosition.x + 6.9f;
            // Calculate a fake ground height
            groundHeight = fakeStagePosition.y - 2.95f;
            // Get player's current color, and set the next color
            currentColor = sprite.color;
            nextColor = Color.black;
        }

        void Update()
        {
            // Always listen to keyboard inputs
            horizontal = Input.GetAxisRaw("Horizontal");
            
            // Get the current velocity
            Vector3 fakePlayerTransform = transform.position;
            
            // Stop the player from moving out of the walls
            if (fakePlayerTransform.x <= leftWall && horizontal < 0)
            {
                horizontal = 0;
            }
            if (fakePlayerTransform.x >= rightWall && horizontal > 0)
            {
                horizontal = 0;
            }

            // Fake grounding
            if (fakePlayerTransform.y <= groundHeight)
            {
                GroundSelf();
            }
            if (isGrounded)
            {
                velocity = jumpForce;
                isGrounded = false;
            }

            // Handle horizontal movement
            fakePlayerTransform.x += 
                moveSpeed * 
                horizontal * 
                Time.unscaledDeltaTime * 
                (PlayerPrefs.HasKey("HorizontalScale") ? PlayerPrefs.GetFloat("HorizontalScale") : 1f);
            
            // Update fake player transform
            if (!isGrounded)
            {
                fakePlayerTransform.y += velocity * Time.unscaledDeltaTime * (PlayerPrefs.HasKey("Scale") ? PlayerPrefs.GetFloat("Scale") : 1f);
                // Decrease velocity by applying gravity
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

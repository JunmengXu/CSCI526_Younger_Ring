using UnityEngine;

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
    [SerializeField] private bool hitWall = false;
    
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
    
    void Update()
    {
        // Always listen to keyboard inputs
        horizontal = Input.GetAxisRaw("Horizontal");
        
        // When the player touches a ground it can land on, jump
        if (isGrounded)
        {
            isGrounded = false;
            velocity = jumpForce;
        }

        // TODO: Implement a new way to handle wall hit in Update()
        #region Temp stuff
        if (transform.position.x > 0 && hitWall)
        {
            horizontal = horizontal > 0 ? 0 : horizontal;
        }
        if (transform.position.x < 0 && hitWall)
        {
            horizontal = horizontal < 0 ? 0 : horizontal;
        }
        
        #endregion
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Tile"))
        {
            // Player can only ground itself when it is falling and
            // will land on a tile with the correct color.
            Color tileColor = col.gameObject.GetComponent<SpriteRenderer>().color;
            if (tileColor == playerColor.currentColor && velocity <= 0)
            {
                isGrounded = true;
                // When grounded, change a new color
                playerColor.ChangeColor();
            }
        }

        // When the player lands on a solid floor, ground itself and change color
        if (col.gameObject.CompareTag("Floor") && velocity <= 0)
        {
            isGrounded = true;
            playerColor.ChangeColor();
        }
        
        // TODO: Implement a new way(probably ray cast) to handle wall hit detection
        // Temporary stuff
        if (col.gameObject.CompareTag("Wall"))
        {
            hitWall = true;
        }

        // When the player collides with the FinishLine, end the game
        if (col.gameObject.CompareTag("FinishLine"))
        {
            gameover = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        // Temporary stuff
        if (other.gameObject.CompareTag("Wall"))
        {
            hitWall = false;
        }
    }

    private void FixedUpdate()
    {
        // Get the current position
        Vector2 position = transform.position;
        
        // Handle horizontal movement
        if (horizontal != 0)
        {
            position.x += moveSpeed * horizontal * Time.fixedDeltaTime;
        }

        // If the player is in air, update vertical position and vertical velocity
        if (!isGrounded)
        {
            position.y += velocity * Time.fixedDeltaTime;
            // Use gravity to pull the player towards the ground
            velocity += gravity * Time.fixedDeltaTime;
        }

        // Update position
        transform.position = position;
    }
}

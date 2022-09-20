using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Used to get the player's current position
    public Player player;

    /// <summary>
    /// Parameters of the main camera
    /// </summary>
    public float initialXPosition;
    public float initialYPosition;
    public float landscapeWidth;
    public float landscapeHeight;
    public float leftEdgeOffset;
    public Camera mainCamera;

    private void FixedUpdate()
    {
        // Get the main camera's current position
        Transform cameraTransform = mainCamera.transform;
        Vector3 currentCameraPosition = cameraTransform.position;
        
        // Move the main camera's position by the unit of the landscape according to the player's position
        Vector3 playerPosition = player.transform.position;
        currentCameraPosition.x = 
            initialXPosition + 
            (int)((playerPosition.x - leftEdgeOffset) / landscapeWidth) * landscapeWidth;
        if (playerPosition.x <= leftEdgeOffset)
        {
            currentCameraPosition.x = 
                initialXPosition - landscapeWidth - 
                (int)(MathF.Abs(playerPosition.x - leftEdgeOffset) / landscapeWidth) * landscapeWidth;
        }
        currentCameraPosition.y = initialYPosition + (int)(playerPosition.y / landscapeHeight) * landscapeHeight;
        cameraTransform.position = currentCameraPosition;
    }
}

using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Player transform
    public Transform playerTransform;
    // Main camera transform
    public Transform mainCameraTransform;
    
    // The following lag between the player and the camera
    public float cameraFollowTimeOffset = 3;

    private void Update()
    {
        // Get the main camera's current position
        Vector3 cameraStartPosition = mainCameraTransform.position;
        // Get the player's current position
        Vector3 playerPosition = playerTransform.position;

        // Create the target Vector3 position variable for the main camera to lerp
        Vector3 targetCameraPosition = new Vector3(
            playerPosition.x,
            playerPosition.y,
            cameraStartPosition.z
        );
        
        // Lerp to gradually drag the camera's position towards the player
        mainCameraTransform.position = Vector3.Lerp(
            cameraStartPosition, 
            targetCameraPosition, 
            cameraFollowTimeOffset * Time.unscaledDeltaTime
        );
    }
}

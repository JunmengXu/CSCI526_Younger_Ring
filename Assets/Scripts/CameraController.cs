using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Used to get the player's current position
    public Player player;

    /// <summary>
    /// Parameters of the main camera
    /// </summary>
    public float initialPosition;
    public float cameraHeight;
    public Camera mainCamera;

    private void FixedUpdate()
    {
        // Get the main camera's current position
        Transform cameraTransform = mainCamera.transform;
        Vector3 currentCameraPosition = cameraTransform.position;
        
        // Move the main camera's position by the unit of cameraHeight according to the player's position
        currentCameraPosition.y = initialPosition + (int)(player.transform.position.y / cameraHeight) * cameraHeight;
        cameraTransform.position = currentCameraPosition;
    }
}

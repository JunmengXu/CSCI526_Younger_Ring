using UnityEngine;

namespace Animations.CameraAnimation.Level3
{
    public class Level3StartCameraZooming : MonoBehaviour
    {
        // Player
        public SpriteRenderer playerSprite;
        public Player player;
        public Colors playerColors;

        public CameraController cameraController;
        public Camera mainCamera;

        public GameObject pressKeyToSkipText;

        public Animator animator;
        private static readonly int Finish = Animator.StringToHash("Finish");

        // Update is called once per frame
        void Update()
        {
            if (animator.GetBool(Finish) || Input.GetKeyDown(KeyCode.Space))
            {
                animator.enabled = false;
                pressKeyToSkipText.SetActive(false);

                playerSprite.enabled = true;
                playerColors.enabled = true;
                player.enabled = true;
                
                cameraController.enabled = true;
                mainCamera.orthographicSize = 5;

                enabled = false;
            }
        }
    }
}

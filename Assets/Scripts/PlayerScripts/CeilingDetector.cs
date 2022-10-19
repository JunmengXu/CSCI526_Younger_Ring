using UnityEngine;

namespace PlayerScripts
{
    public class CeilingDetector : MonoBehaviour
    {

        public Player player;

        private void OnTriggerEnter2D(Collider2D col)
        {
            // To detect collision with walls coming from the top.
            if (!col.gameObject.CompareTag("Tile") &&
                !col.gameObject.CompareTag("Floor") &&
                !col.gameObject.CompareTag("NoColorTile"))
            {
                // Start to fall when bumping into a "ceiling"(Wall on top)
                player.SetVelocity(0);
            }
        }
    }
}

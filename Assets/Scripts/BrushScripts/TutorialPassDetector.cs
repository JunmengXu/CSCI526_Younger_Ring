using UnityEngine;

namespace BrushScripts
{
    public class TutorialPassDetector : MonoBehaviour
    {
        public Player player;

        public bool partTwoComplete = false;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (player.GetVelocity() <= 0)
            {
                partTwoComplete = true;
            }
        }
    }
}

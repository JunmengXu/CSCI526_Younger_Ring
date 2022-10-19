using TMPro;
using UnityEngine;

namespace UIController
{
    public class UIColorController : MonoBehaviour
    {
        // Local variable to hold the player's Colors instance
        public Colors playerColor;

        // The dot after "Next Color: "
        public TMP_Text nextColorText;

        void Update()
        {
            // Update the dot's color
            nextColorText.color = playerColor.nextColor;
        }
    }
}

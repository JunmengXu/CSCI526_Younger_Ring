using TMPro;
using UnityEngine;

namespace ColorAdd
{
    public class UIColorController : MonoBehaviour
    {
        // Used to get the player's Colors component
        public GameObject player;
        
        // Local variable to hold the player's Colors instance
        private Colors playerColor;

        // The dot after "Next Color: "
        //public TMP_Text nextColorText;
        
        void Start()
        {
            playerColor = player.GetComponent<Colors>();
        }
        
        void Update()
        {
            // Update the dot's color
            //nextColorText.color = playerColor.nextColor;
        }
    }
}

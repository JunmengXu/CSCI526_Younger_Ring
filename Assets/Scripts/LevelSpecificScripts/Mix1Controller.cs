using TMPro;
using UnityEngine;

namespace LevelSpecificScripts
{
    public class Mix1Controller : MonoBehaviour
    {

        public GameObject magnet;

        public TMP_Text obstacleRemainHealth;

        // Update is called once per frame
        void Update()
        {
            if (obstacleRemainHealth.text == "0")
            {
                magnet.SetActive(true);
            }
        }
    }
}

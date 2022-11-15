using UnityEngine;

namespace LevelSpecificScripts
{
    public class Mix1Controller : MonoBehaviour
    {
        public GameObject magnet;
        public GameObject obstacle;

        // Update is called once per frame
        void Update()
        {
            if (!obstacle.activeSelf)
            {
                magnet.SetActive(true);
            }
        }
    }
}

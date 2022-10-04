using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorAdd
{
    public class TutorialTileTouch : MonoBehaviour
    {
        private bool firstTouch = false;

        // Start is called before the first frame update
        void Start()
        {
            firstTouch = false;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                firstTouch = true;
            }
        }

        public bool getFirstTouch()
        {
            return firstTouch;
        }
    }
}

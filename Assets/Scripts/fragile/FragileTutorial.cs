using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fragile1Script
{
    public class FragileTutorial : MonoBehaviour
    {

        public GameObject hitPlatformText;
        
        public GameObject coolDownText;

        private Boolean isFinished = false;

        private Boolean isShowingSecond = false;
        
        

        // Start is called before the first frame update
        void Start()
        {
            hitPlatformText.SetActive(true);
            coolDownText.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (isFinished)
            {
                hitPlatformText.SetActive(false);
                coolDownText.SetActive(false);
                return;
            }

            if (col.relativeVelocity.y <= 0f)
            {
                if (isShowingSecond)
                {
                    return;
                }
                isShowingSecond = true;
                hitPlatformText.SetActive(false);
                coolDownText.SetActive(true);
                StartCoroutine(FinishTutorial());
            }
        }

        IEnumerator FinishTutorial()
        {
            yield return new WaitForSeconds(3);
            hitPlatformText.SetActive(false);
            coolDownText.SetActive(false);
            isFinished = true;
        }
        
        
    }

}

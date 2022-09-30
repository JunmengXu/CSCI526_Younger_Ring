using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    public GameObject[] popUps;
    public GameObject Player;
    private int popUpIndex;
    private void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex || i == popUpIndex + 1)
            {
                Debug.Log(i);
                popUps[i].SetActive(true);

            } else
            {
                popUps[i].SetActive(false);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space) && popUpIndex < popUps.Length) {
            if(popUpIndex <= popUps.Length - 3) { popUpIndex += 2; } else
            {
                popUpIndex++;
            }
                
            
        }
        if(popUpIndex == popUps.Length) {
            popUps[popUpIndex - 1].SetActive(false);
            Player.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }

        

    }
}

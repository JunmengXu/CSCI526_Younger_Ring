using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endlessPlayer : MonoBehaviour
{
    public bool gameover;
    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        
        if (col.gameObject.CompareTag("MainCamera"))
        {
            gameover = true;
        }
    }
}

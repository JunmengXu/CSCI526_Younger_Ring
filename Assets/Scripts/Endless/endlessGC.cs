using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endlessGC : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        if(gameObject.transform.position.y + 5 < player.transform.position.y)
        {
            gameObject.SetActive(false);
        }
    }
}

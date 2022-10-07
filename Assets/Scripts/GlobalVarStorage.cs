using System;
using UnityEngine;

public class GlobalVarStorage : MonoBehaviour
{
    // Start is called before the first frame update

    // sessionID to uniquely identify a gameplay
    public static long globalSessionID;


    void Start()
    {
        globalSessionID = DateTime.Now.Ticks;
        Debug.Log("SessionID created: " + globalSessionID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

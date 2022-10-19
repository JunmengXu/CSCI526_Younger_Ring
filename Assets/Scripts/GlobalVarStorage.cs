using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVarStorage : MonoBehaviour
{
    // Start is called before the first frame update

    // sessionID to uniquely identify a gameplay
    public static long globalSessionID = DateTime.Now.Ticks;

    void Start()
    {
        Debug.Log("SessionID created: " + globalSessionID);
    }

    void Awake()
    {
        //DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

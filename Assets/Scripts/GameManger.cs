using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManger : MonoBehaviour
{
    public Action quitAction;
    public static GameManger instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        instance = this;
    }

    private void OnApplicationQuit()
    {

        quitAction?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

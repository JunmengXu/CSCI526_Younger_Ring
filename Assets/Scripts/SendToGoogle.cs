using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Random = System.Random;


public class SendToGoogle : MonoBehaviour
{
    [SerializeField] private string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScFCS1y7G75FnXM0PLnNMgHerX49ZXw12iMFBb9wjo-wDLPkw/formResponse";

    private long _sessionID;
    private int _testInt;

    private void Awake()
    {
        _sessionID = DateTime.Now.Ticks;

        Send();
    }

    private void Send()
    {
        Random r = new Random();
        _testInt = r.Next(0, 20);

        StartCoroutine(Post(_sessionID.ToString(), _testInt.ToString()));
    }

    private IEnumerator Post(string sessionID, string randInt)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1775625545", sessionID);
        form.AddField("entry.2061129056", randInt);

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Succeess!");
            }
        }

    }
}

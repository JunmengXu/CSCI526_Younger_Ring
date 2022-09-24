using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SendToGoogle : MonoBehaviour
{
    [SerializeField] private string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScFCS1y7G75FnXM0PLnNMgHerX49ZXw12iMFBb9wjo-wDLPkw/formResponse";

    public long sessionID;
    public int level;
    public string levelClearTime;
    public int numNumps;

    //private void Awake()
    //{
    //    sessionID = DateTime.Now.Ticks;

    //    Send();
    //}

    public void Send()
    {
        StartCoroutine(Post(sessionID.ToString(), level.ToString(), levelClearTime.ToString(), numNumps.ToString()));
    }

    private IEnumerator Post(string session, string numLevel, string levelTime, string jumps)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1775625545", session); 
        form.AddField("entry.2019722355", numLevel);
        form.AddField("entry.2061129056", levelTime);
        form.AddField("entry.519829308", jumps);

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

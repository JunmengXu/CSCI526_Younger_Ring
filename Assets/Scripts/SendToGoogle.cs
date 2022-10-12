using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class SendToGoogle : MonoBehaviour
{
    [SerializeField] private string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScFCS1y7G75FnXM0PLnNMgHerX49ZXw12iMFBb9wjo-wDLPkw/formResponse";

    // Global unique ID for a gamplay
    public long sessionID;

    // level index in build
    public int levelIndex;

    // uniquely identify a single play even in same level
    public long uniqueLevelID;

    // a list containing path data
    // (<x, y, time>, ...)
    public List<string> playerPath = new List<string>();

    // current timestamp
    public string timestamp;

    //  status of game:
    //  0 - start of level
    //  1 - finish level
    //  2 - quit/retry before goal (scene destroyed) TODO
    public int status;

    // player in the scene
    public Player player;

    // bool to control send to Google 
    private bool send;


    // on the start of each scene, send to Google
    private void Start()
    {

        this.sessionID = GlobalVarStorage.globalSessionID;

        this.levelIndex = SceneManager.GetActiveScene().buildIndex;

        this.timestamp = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

        this.uniqueLevelID = DateTime.Now.Ticks;

        this.status = 0;

        this.send = true;

        Send();

        // Continuously get the position
        // fixme: fix repeat time to match jump timescale
        InvokeRepeating("GetPosition", 0.0f, 1.5f);
    }


    // send to Google once player hit finish line
    void Update()
    {

        if (player.gameover && send)
        {

            this.timestamp = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            this.status = 1;

            Send();

            // send only once 
            send = false;

            CancelInvoke("GetPosition");
        }

    }


    private void OnDestroy()
    {
        // fixme: not able to send
        this.timestamp = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
        this.status = 2;
        string path = String.Join(", ", playerPath.ToArray());
        Post(sessionID.ToString(), levelIndex.ToString(), uniqueLevelID.ToString(), timestamp.ToString(), status.ToString(), path);
    }

    // Get the player position x and y, and add timestamp
    void GetPosition()
    {
        float posX = player.GetHorizontalPos();
        float posY = player.GetVerticalPos();

        this.timestamp = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

        Tuple<float, float, string> currPosInfo = new Tuple<float, float, string>(posX, posY, this.timestamp);

        playerPath.Add(currPosInfo.ToString());
    }

    public void Send()
    {
        string path = "Null";
        if (this.status != 0)
        {
            path = String.Join(", ", playerPath.ToArray());
        }
    }

    private IEnumerator Post(string session, string levelIndex, string ULID, string timestamp, string status, string wholePath)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1775625545", session);
        form.AddField("entry.2019722355", levelIndex);
        form.AddField("entry.1757100219", ULID);
        form.AddField("entry.2061129056", timestamp);
        form.AddField("entry.519829308", status);
        form.AddField("entry.794095359", wholePath); 

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

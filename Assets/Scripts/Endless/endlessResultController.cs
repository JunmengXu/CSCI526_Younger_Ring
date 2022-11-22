using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class endlessResultController : MonoBehaviour
{
    public GameObject resultScreen;
        
    public endlessPlayer player;

    public Button retryButton;
    public Button selectLevelButton;

    // "You score is " Text
    public TMP_Text result;

    // Score text on the top left
    public TMP_Text score;

    // Set player's name
    [SerializeField] public TMP_Text playerName;
    public Button confirmNameButton;
    private string playername = "player";
    
    // leaderboard socre list
    // List<List<string>> leaderboardList;
    // XmlNodeList xmlNodeList;
    // private int leaderboardMinScore = 1000;

    public TMP_Text leaderboard;

    void Start()
    {
        // TODO: Move the Time setting to a new global controller
        Time.timeScale = 1;
        
        // At the start, hide self
        resultScreen.SetActive(false);
        
        retryButton.onClick.AddListener(ResetGame);

        selectLevelButton.onClick.AddListener(SelectLevel);

        confirmNameButton.onClick.AddListener(confirmName);


        GetHighScores();
        // #if UNITY_EDITOR
        //     Debug.Log("Unity Editor");
        //     leaderboardList = ReadCSV.Read(Application.dataPath + "/Resources/Endless Leaderboard.csv", Encoding.UTF8);
        // #elif UNITY_WEBGL
        //     Debug.Log("WebGL");
        //     string leaderboardList = Resources.Load<TextAsset>("Endless Leaderboard.csv.bytes").text;
        //     leaderboardList = ReadCSV.ReadOnWebGL(leaderboardList);
        // #else
        //     Debug.Log("PC");
        //     leaderboardList = ReadCSV.Read(Application.dataPath + "/Resources/Endless Leaderboard.csv", Encoding.UTF8);
        // #endif

        // int playerCount = Math.Min(leaderboardList.Count, 16);
        // if(playerCount > 0)
        // {
        //     leaderboardMinScore = int.Parse(leaderboardList[playerCount-1][1]);
        //     string result = "";
        //     for(int i = 1; i < playerCount; i++)
        //     {
        //         string cur = "";
        //         int score = int.Parse(leaderboardList[i][1]);
        //         leaderboardMinScore = Math.Min(leaderboardMinScore, score);
        //         string name = leaderboardList[i][2];
        //         cur += i;
        //         while(cur.Length<9){
        //             cur += " ";
        //         }
        //         cur += score;
        //         while(cur.Length<19){
        //             cur += " ";
        //         }
        //         cur += name + "\n";
        //         result += cur;
        //     }
        //     leaderboard.text = result;
        // }


        // XmlDocument xml = new XmlDocument();

        // #if UNITY_EDITOR
        //     Debug.Log("Unity Editor");
        //     xml.Load(Application.dataPath + "/Resources/Endless Leaderboard.xml");
        // #elif UNITY_WEBGL
        //     Debug.Log("WebGL");
        //     // xml = Resources.Load("Endless Leaderboard") as XmlDocument;
        //     xml.Load(Application.dataPath+"Endless Leaderboard");
        //     string str = Resources.Load<TextAsset>("Endless Leaderboard").text;
        //     StringReader Reader = new StringReader(str);
        //     xml.Load(Reader);
        // #else
        //     Debug.Log("PC");
        //     xml.Load(Application.dataPath + "/Resources/Endless Leaderboard.xml");
        // #endif

        // xmlNodeList = xml.SelectSingleNode("Node").ChildNodes;
        // int playerCount = Math.Min(xmlNodeList.Count, 16);
        // leaderboardList = new List<List<string>>();
        // string result = "";
        // //遍历所有子节点
        // for(int i = 0; i < playerCount; i++){
        //     int index = i+1;
        //     List<string> playerlist = new List<string>();
        //     int score = 0;
        //     string name = "";
        //     foreach (XmlElement xl2 in xmlNodeList[i].ChildNodes)
        //     {
        //         if(xl2.Name == "Score"){
        //             int tryscore = 0;
                
        //             if(int.TryParse(xl2.InnerText, out tryscore)) // TryParse returns a boolean showing whether the parse worked
        //             {
        //                 score = tryscore;
        //                 // int score = int.Parse(xl2.InnerText);
        //                 leaderboardMinScore = Math.Min(leaderboardMinScore, score);
        //             }
        //         }
        //         if(xl2.Name == "Name"){
        //             name = xl2.InnerText;
        //         }
        //     }

        //     string cur = "";
        //     cur += index;
        //     while(cur.Length<9){
        //         cur += " ";
        //     }
        //     cur += score;
        //     while(cur.Length<19){
        //         cur += " ";
        //     }
        //     cur += name + "\n";
        //     result += cur;
        //     playerlist.Add(index.ToString());
        //     playerlist.Add(score.ToString());
        //     playerlist.Add(name);

        //     leaderboardList.Add(playerlist);
        // }
        // leaderboard.text = result;
    }

    void ResetGame()
    {
        // updateLeaderBoard();
        int playerScore = int.Parse(score.text);
        AddScore(playername, playerScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    void SelectLevel()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    void confirmName()
    {
        playername = playerName.text;
        playername.Trim();
        if(string.IsNullOrEmpty(playername)){
            playername = "player";
        }
        ResetGame();
    }

    // void updateLeaderBoard()
    // {
    //     int playerScore = int.Parse(score.text);
    //     int playerCount = Math.Min(leaderboardList.Count, 15);
    //     if(playerScore > leaderboardMinScore || playerCount<15){
    //         string path = Application.dataPath + "/Resources/Endless Leaderboard.xml";
    //         //创建xml文档
    //         XmlDocument xml = new XmlDocument();
    //         //创建根节点
    //         XmlElement root = xml.CreateElement("Node");

    //         bool record = false;
    //         if(playerCount > 0)
    //         {
    //             int index = 1;
    //             for(int i = 0; i < playerCount; i++)
    //             {
    //                 int curscore = int.Parse(leaderboardList[i][1]);
    //                 string name = leaderboardList[i][2];
    //                 if(playerScore > curscore && !record){
    //                     //创建根节点的子节点
    //                     XmlElement element = xml.CreateElement("Player");
    //                     //设置根节点的子节点的属性
    //                     element.SetAttribute("rank", index.ToString());
    //                     //添加两个子节点到根节点的子节点的下面
    //                     XmlElement elementChild1 = xml.CreateElement("Name");
    //                     elementChild1.SetAttribute("name", "");
    //                     elementChild1.InnerText = playername;
    //                     XmlElement elementChild2 = xml.CreateElement("Score");
    //                     elementChild2.SetAttribute("score", "");
    //                     elementChild2.InnerText = playerScore.ToString();
    //                     //把节点一层一层的添加至xml中，注意他们之间的先后顺序，这是生成XML文件的顺序
    //                     element.AppendChild(elementChild1);
    //                     element.AppendChild(elementChild2);

    //                     root.AppendChild(element);
    //                     record = true;
    //                     index++;
    //                 }
    //                 //再创建一个根节点的子节点
    //                 XmlElement element2 = xml.CreateElement("Player");
    //                 //设置根节点的子节点的属性 名字一样 属性不一样也可以
    //                 element2.SetAttribute("rank", index.ToString());
    //                 //添加两个子节点到根节点的子节点的下面
    //                 XmlElement elementChild3 = xml.CreateElement("Name");
    //                 elementChild3.SetAttribute("name", "");
    //                 elementChild3.InnerText = name;
    //                 XmlElement elementChild4 = xml.CreateElement("Score");
    //                 elementChild4.SetAttribute("score", "");
    //                 elementChild4.InnerText = curscore.ToString();
    //                 element2.AppendChild(elementChild3);
    //                 element2.AppendChild(elementChild4);

    //                 root.AppendChild(element2);
    //                 index++;

    //                 if(i==playerCount-1 && !record){
    //                     //创建根节点的子节点
    //                     XmlElement element = xml.CreateElement("Player");
    //                     //设置根节点的子节点的属性
    //                     element.SetAttribute("rank", index.ToString());
    //                     //添加两个子节点到根节点的子节点的下面
    //                     XmlElement elementChild1 = xml.CreateElement("Name");
    //                     elementChild1.SetAttribute("name", "");
    //                     elementChild1.InnerText = playername;
    //                     XmlElement elementChild2 = xml.CreateElement("Score");
    //                     elementChild2.SetAttribute("score", "");
    //                     elementChild2.InnerText = playerScore.ToString();
    //                     //把节点一层一层的添加至xml中，注意他们之间的先后顺序，这是生成XML文件的顺序
    //                     element.AppendChild(elementChild1);
    //                     element.AppendChild(elementChild2);

    //                     root.AppendChild(element);
    //                     record = true;
    //                     index++;
    //                 }
    //             }
    //         }
    //         xml.AppendChild(root);

    //         //最后保存文件
    //         xml.Save(path);
    //     }
    // }

    void AddScore(string name, int score)
    {
        int newScore;
        string newName;
        int oldScore;
        string oldName;
        newScore = score;
        newName = name;
        for(int i=0;i<15;i++){
            if(PlayerPrefs.HasKey(i+"HScore")){
                if(PlayerPrefs.GetInt(i+"HScore")<newScore){ 
                    // new score is higher than the stored score
                    oldScore = PlayerPrefs.GetInt(i+"HScore");
                    oldName = PlayerPrefs.GetString(i+"HScoreName");
                    PlayerPrefs.SetInt(i+"HScore",newScore);
                    PlayerPrefs.SetString(i+"HScoreName",newName);
                    newScore = oldScore;
                    newName = oldName;
                }
            }else{
                PlayerPrefs.SetInt(i+"HScore",newScore);
                PlayerPrefs.SetString(i+"HScoreName",newName);
                newScore = 0;
                newName = "";
            }
        }
    }

    void GetHighScores()
    {
        // for(int i = 0; i < 10; i++)
        // {
        //     Debug.Log(PlayerPrefs.GetString(i + "HScoreName") + " has a score of: " +  PlayerPrefs.GetInt(i + "HScore"));
        // }
        string result = "";
        for(int i = 0; i < 15; i++)
        {
            // List<string> playerlist = new List<string>();
            string cur = "";

            int score = PlayerPrefs.GetInt(i + "HScore");
            string name = PlayerPrefs.GetString(i + "HScoreName");

            cur += (i+1);
            while(cur.Length<9){
                cur += " ";
            }
            cur += score;
            while(cur.Length<19){
                cur += " ";
            }
            cur += name + "\n";
            result += cur;

            // playerlist.Add((i+1).ToString());
            // playerlist.Add(score.ToString());
            // playerlist.Add(name);

            // leaderboardList.Add(playerlist);
        }
        leaderboard.text = result;
        
    }

    // Update is called once per frame
    void Update()
    {
        // When the player gets to the finish line, pause the game and show resultScreen
        if (player.gameover)
        {
            Time.timeScale = 0;
            result.text = "You score is " + score.text + " !";
            resultScreen.SetActive(true);
        }
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace UIController
{
    public class ResultScreenController : MonoBehaviour
    {
        public GameObject resultScreen;
        
        public Player player;
    
        public Button retryButton;
        public Button selectLevelButton;

        public string nextLevelSceneStr;

        // "You used ...s" Text
        public TMP_Text result;

        // Timer text on the top right
        public TMP_Text timer;
        
        //User's avg time list
        List<List<string>> avgTimeList;
        //User's standard deviation list
        List<List<string>> stdTimeList;
        int index;
        void Start()
        {
            // TODO: Move the Time setting to a new global controller
            Time.timeScale = 1;
            
            // At the start, hide self
            resultScreen.SetActive(false);
            
            retryButton.onClick.AddListener(ResetGame);

            selectLevelButton.onClick.AddListener(SelectLevel);

            index = SceneManager.GetActiveScene().buildIndex;
            #if UNITY_EDITOR
                Debug.Log("Unity Editor");
                avgTimeList = ReadCSV.Read(Application.dataPath + "/Resources/3 - Avg Level Clear Time.csv", Encoding.Default);
                stdTimeList = ReadCSV.Read(Application.dataPath + "/Resources/7 - Std Level Clear Time.csv", Encoding.Default);
            #elif UNITY_WEBGL
                Debug.Log("WebGL");
                string avgTimeStr = Resources.Load<TextAsset>("3 - Avg Level Clear Time.csv.bytes").text;
                string stdTimeStr = Resources.Load<TextAsset>("7 - Std Level Clear Time.csv.bytes").text;
                avgTimeList = ReadCSV.ReadOnWebGL(avgTimeStr);
                stdTimeList = ReadCSV.ReadOnWebGL(stdTimeStr);
            #else
                Debug.Log("PC");
                avgTimeList = ReadCSV.Read(Application.dataPath + "/Resources/3 - Avg Level Clear Time.csv", Encoding.Default);
                stdTimeList = ReadCSV.Read(Application.dataPath + "/Resources/7 - Std Level Clear Time.csv", Encoding.Default);
            #endif
        }
    
        void ResetGame()
        {
            //SceneManager.LoadScene(nextLevelSceneStr);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        void SelectLevel()
        {
            SceneManager.LoadScene("LevelMenu");
        }

        // Update is called once per frame
        void Update()
        {
            // When the player gets to the finish line, pause the game and show resultScreen
            if (player.gameover)
            {
                Time.timeScale = 0;
                int levelCount = Math.Min(avgTimeList.Count, avgTimeList.Count);
                //If levelCount is 0, it means that we failed to read the file
                //If index is greater than levelCount, it means that the level is a new level whose data is not in the file
                if(levelCount > 0 && index <= levelCount)
                {
                    double avgTime = 10.0;
                    double stdTime = 5.0;
                    for(int i = 1; i < levelCount; i++)
                    {
                        //Find the corresponding level
                        if(index == int.Parse(avgTimeList[i][0]))
                        {
                            avgTime = double.Parse(avgTimeList[i][1]);
                            stdTime = double.Parse(stdTimeList[i][1]);
                        }
                    }
                    double userTime = double.Parse(timer.text);
                    //Calculate the normal distribution value (currently not used)
                    double p = Normal(userTime, avgTime, stdTime);
                    //Calculate the cumulative distribution value
                    //For any normal distribution X ∼ N(µ, σ^2), we can standardize it to a standard normal distribution Z ∼ N(0, 1) by Z = (X - µ) / σ
                    double cnd = CND((userTime - avgTime)/stdTime);
                    double percent = (1.0 - cnd) * 100;
                    result.text = "You used " + timer.text + "s and beat " + percent.ToString("0.00") + "% of players!";
                }
                else
                {
                    result.text = "You used " + timer.text + "s!";
                }
                resultScreen.SetActive(true);
            }
        }

        // Normal distribution
        public double Normal(double x, double miu, double sigma)
        {
            return 1.0 / (x * Math.Sqrt(2 * Math.PI) * sigma) * Math.Exp(-1 * (Math.Log(x) - miu) * (Math.Log(x) - miu) / (2 * sigma * sigma));
        }

        //Cumulative normal distribution function of a standard normal (Gaussian) random variable
        public static double CND(double d)
        {
            const double       A1 = 0.31938153;
            const double       A2 = -0.356563782;
            const double       A3 = 1.781477937;
            const double       A4 = -1.821255978;
            const double       A5 = 1.330274429;
            const double RSQRT2PI = 0.39894228040143267793994605993438;

            double
            K = 1.0 / (1.0 + 0.2316419 * Math.Abs(d));

            double
            cnd = RSQRT2PI * Math.Exp(- 0.5 * d * d) *
                (K * (A1 + K * (A2 + K * (A3 + K * (A4 + K * A5)))));

            if (d > 0)
                cnd = 1.0 - cnd;

            return cnd;
        }
    }
}

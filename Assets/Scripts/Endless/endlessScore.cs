using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class endlessScore : MonoBehaviour
{
    private int score;

    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score = (int) Camera.main.transform.position.y;
        scoreText.text = score.ToString();
    }
}

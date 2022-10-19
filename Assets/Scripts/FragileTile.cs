using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FragileTile : MonoBehaviour
{
    public float r = 1.0f;

    public float g = 1.0f;

    public float b = 1.0f;

    // Start is called before the first frame update
    public int defaultCount = 3;

    public int defaultRestoreTime = 10;
    
    private int count;
    
    public int restoreTime = 0;

    public GameObject brick;
    
    private GameObject jumpText;

    private TextMeshPro jumpTextMesh;

    private GameObject countDownText;

    private TextMeshPro countDownTextMesh;

    private Color brickColor;

    private Color textColor;
    void Start()
    {
        SetUp();
    }

    void ColorSetUp()
    {
        var currColor = brick.GetComponent<SpriteRenderer>().color;
        brickColor = new Color(currColor.r, currColor.g, currColor.b, currColor.a);
        jumpTextMesh.color = new Color(r, g, b, 1.0f);
        countDownTextMesh.color = new Color(r, g, b, 1.0f);
    }

    void SetUp()
    {
        count = defaultCount;
        restoreTime = 0;
        jumpText = new GameObject();
        jumpText.AddComponent<TextMeshPro>();
        jumpText.transform.parent = brick.transform;
        jumpText.transform.localPosition = new Vector3(0, 0, 0);
        jumpText.transform.SetAsLastSibling();
        jumpTextMesh = jumpText.GetComponent(typeof(TextMeshPro)) as TextMeshPro;
        if (jumpTextMesh != null)
        {
            jumpTextMesh.alignment = TextAlignmentOptions.Center;
            jumpTextMesh.text = count.ToString();
            jumpTextMesh.fontSize = 5;
        }

        countDownText = new GameObject();
        countDownText.AddComponent<TextMeshPro>();
        countDownText.transform.parent = brick.transform;
        countDownText.transform.localPosition = new Vector3(0, 0, 0);
        countDownText.transform.SetAsLastSibling();
        countDownTextMesh = countDownText.GetComponent<TextMeshPro>();
        countDownTextMesh.alignment = TextAlignmentOptions.Center;
        countDownTextMesh.text = defaultRestoreTime + " S";
        countDownTextMesh.fontSize = 5;
        ColorSetUp();
        countDownText.SetActive(false);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.relativeVelocity.y <= 0f)
        {
            count--;
            if (count > 0 )
            {
                jumpTextMesh.text = count.ToString();
            }
            else
            {
                Debug.Log("disable and invisible");
                DisableAndInvisible();
                count = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CountDown()
    {
        restoreTime = defaultRestoreTime;
        while (restoreTime > 0)
        {
            countDownTextMesh.text = restoreTime + " S";
            yield return new WaitForSeconds(1.0f);
            restoreTime -= 1;
        }

    }

    IEnumerator Recover()
    {
        yield return new WaitForSeconds(defaultRestoreTime);
        count = defaultCount;
        SpriteRenderer renderer = brick.GetComponent<SpriteRenderer>();
        renderer.color = new Color(brickColor.r, brickColor.g, brickColor.b, 1.0f);
        ((BoxCollider2D)brick.GetComponent(typeof(BoxCollider2D))).enabled = true;
        jumpText.SetActive(true);
        countDownText.SetActive(false);
        jumpTextMesh.text = count.ToString();
        
    }

    private void DisableAndInvisible()
    {
        SpriteRenderer renderer = brick.GetComponent<SpriteRenderer>();
        renderer.color = new Color(brickColor.r, brickColor.g, brickColor.b, 0.2f);
        ((BoxCollider2D)brick.GetComponent(typeof(BoxCollider2D))).enabled = false;
        restoreTime = defaultRestoreTime ;
        jumpText.SetActive(false);
        countDownText.SetActive(true);
        StartCoroutine(CountDown());
        StartCoroutine(Recover());
    }
    
}

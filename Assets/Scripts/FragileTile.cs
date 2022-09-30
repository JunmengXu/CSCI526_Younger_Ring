using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FragileTile : MonoBehaviour
{
    // Start is called before the first frame update
    public int count = 3;

    public GameObject brick;
    
    private GameObject text;

    private TextMeshPro textMesh;
    void Start()
    {
        Debug.Log(":test");
        text = new GameObject();
        text.AddComponent<TextMeshPro>();
        text.transform.parent = brick.transform;
        text.transform.localPosition = new Vector3(0, 0, 0);
        // text.layer = LayerMask.GetMask("Blue");
        text.transform.SetAsLastSibling();
        textMesh = text.GetComponent(typeof(TextMeshPro)) as TextMeshPro;
        textMesh.alignment = TextAlignmentOptions.Center;
        textMesh.text = count.ToString();
        textMesh.fontSize = 5;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("fragile collide");
        if (count > 0 )
        {
            count--;
        }
        else
        {
            count = 0;
        }
        textMesh.text = count.ToString();

    }


    // Update is called once per frame
    void Update()
    {
        if (count <= 0)
        {
            StartCoroutine(Recover());
            DisableAndInvisible();
        }
    }

    IEnumerator Recover()
    {
        yield return new WaitForSeconds(3.0f);
        Debug.Log("recover");
        count = 3;
        (brick.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer).enabled = true;
        (brick.GetComponent(typeof(BoxCollider2D)) as BoxCollider2D).enabled = true;
        text.SetActive(true);
        textMesh.text = count.ToString();
    }

    private void DisableAndInvisible()
    {
        (brick.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer).enabled = false;
        (brick.GetComponent(typeof(BoxCollider2D)) as BoxCollider2D).enabled = false;
        // brick.SetActive(false);
        text.SetActive(false);
    }
}

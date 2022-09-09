using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float speed = 100f;
    public float jumpSpeed;
    public Transform m_transform;
    Rigidbody playerRigidbody;
    GameObject m_text;

    float jumpTime = 2.5f;
    private bool grounded;
    public float jumpHeight = 2f;

    // Start is called before the first frame update
    void Start()
    {
        m_text = GameObject.FindGameObjectWithTag("lose");
        m_text.SetActive(false);
        m_transform = this.transform;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            m_transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            m_transform.Translate(Vector3.right* Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.Space) && grounded ==true)
        {
            //grounded = false;

            //playerRigidbody.velocity += new Vector3(0, 0.1f, 0);
            //playerRigidbody.AddForce(Vector3.up * 4f);
            playerRigidbody.velocity = Vector3.up * 6.0f;
            grounded = false;
        }

        //if(!grounded)
        //{
            //jumpTime -= Time.deltaTime;
        //}
    }

    /*
    void FixedUpdate()
    {
        if(!grounded && jumpTime > 0)
        {
            playerRigidbody.velocity += new Vector3(0, 0.1f, 0);
            playerRigidbody.AddForce(0, jumpHeight, 0);
        }
    }

    */
    void OnCollisionEnter(Collision collision)
    {
        //jumpTime = 2.5f;
        grounded = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "track1")
        {
            m_text.SetActive(true);
        }
    }
}


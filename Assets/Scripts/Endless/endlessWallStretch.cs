using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class endlessWallStretch : MonoBehaviour
{
    // the scale of catapult in x & y
    private float scaleX;
    private float scaleY;

    // MAX & MIN length the catapult
    [SerializeField] private float maxLength;
    private float minLength;

    // if the catapult is stretching or shrinking
    private bool isStretching = true;

    // position of the catapult
    private float posX;
    private float posY;

    // the speed of the catapult's stretch or shrink
    [SerializeField] private float stretchSpeed = 0.01f;

    // the rotation of the catapult, we need to know the degree and its radians
    private float rotationZDegree;
    private float rotationZRadians;

    public Player player;

    // After hit by catapult, player's speed will be playerSpeed
    [SerializeField] private float playerSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        var scale = transform.localScale;
        scaleX = scale.x;
        scaleY = scale.y;
        minLength = scale.x;

        var position = transform.position;
        posX = position.x;
        posY = position.y;

        var rotation = transform.localEulerAngles;
        rotationZDegree = rotation.z;
        
        rotationZRadians = rotationZDegree / 180 * Mathf.PI;
        
    }

    void OnEnable()
    {
        var scale = transform.localScale;
        scaleX = scale.x;
        scaleY = scale.y;
        minLength = scale.x;

        var position = transform.position;
        posX = position.x;
        posY = position.y;

        var rotation = transform.localEulerAngles;
        rotationZDegree = rotation.z;
        
        rotationZRadians = rotationZDegree / 180 * Mathf.PI;
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // playerSpeed is the speed with the same direction as the catapult. We need to divide it into horizontal and vertical direction
            player.isHitByCatapult = true;
            player.velocity = playerSpeed * Mathf.Sin(rotationZRadians);
            player.horizontalVelocity = playerSpeed * Mathf.Cos(rotationZRadians);
        }
    }
}

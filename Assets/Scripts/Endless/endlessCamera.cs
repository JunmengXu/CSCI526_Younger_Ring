using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endlessCamera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.3f;
    Vector3 speed;

    private void LateUpdate()
    {
        if(target.position.y-5f > transform.position.y)
        {
            Vector3 targetPos = new Vector3(0f, target.position.y-5f, -10f);
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref speed, smoothSpeed * Time.deltaTime);
        }
    }
}

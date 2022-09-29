using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    public Transform player;

    private void LateUpdate()
    {
        Vector2 playerPosition = player.position;
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = playerPosition.x;
        cameraPosition.y = playerPosition.y;
        transform.position = cameraPosition;
    }
}

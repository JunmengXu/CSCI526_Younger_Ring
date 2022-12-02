using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endlessTile : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D col)
    {
        // When the tiles exit from main camera, set them invisible.
        if (col.gameObject.CompareTag("MainCamera"))
        {
            // Debug.Log("disapper");
            gameObject.SetActive(false);
        }
    }
}

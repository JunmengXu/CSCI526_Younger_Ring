using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    private RectTransform miniMap;

    private void Start()
    {
        miniMap = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            miniMap.anchoredPosition = new Vector2(-405, -405);
            miniMap.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 750);
            miniMap.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 750);
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            miniMap.anchoredPosition = new Vector2(-180, -180);
            miniMap.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300);
            miniMap.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 300);
        }
    }
}

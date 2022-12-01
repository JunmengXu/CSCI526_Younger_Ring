using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PauseScreenScripts.HandbookScripts
{
    public class TabButton : MonoBehaviour, IPointerClickHandler
    {
        public Tabs tabs;

        public Image tabButtonImage;

        public void OnPointerClick(PointerEventData eventData)
        {
            tabs.OnTabSelected(this);
        }
    }
}

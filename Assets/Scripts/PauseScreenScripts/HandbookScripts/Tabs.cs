using System.Collections.Generic;
using UnityEngine;

namespace PauseScreenScripts.HandbookScripts
{
    public class Tabs : MonoBehaviour
    {
        public List<TabButton> tabButtons;
        
        public Sprite normal;
        public Sprite selected;

        public List<GameObject> tabContent;

        public void OnTabSelected(TabButton tabButton)
        {
            ResetTabs();
            tabButton.tabButtonImage.sprite = selected;

            int tabButtonIndex = tabButton.transform.GetSiblingIndex();
            for (int i = 0; i < tabContent.Count; i++)
            {
                if (i == tabButtonIndex)
                {
                    tabContent[i].SetActive(true);
                }
                else
                {
                    tabContent[i].SetActive(false);
                }
            }
        }

        private void ResetTabs()
        {
            foreach (TabButton tabButton in tabButtons)
            {
                tabButton.tabButtonImage.sprite = normal;
            }
        }
    }
}

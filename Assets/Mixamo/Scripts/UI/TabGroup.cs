using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public TabButton SelectedTab;
    public List<GameObject> ObjectsTpSwap;


    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)        
            tabButtons = new List<TabButton>();        
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if(SelectedTab == null || button != SelectedTab)
            button.Background.sprite = tabHover;
    }
    public void OnTabExit(TabButton button)
    {
        ResetTabs();        
    }
    public void OnTabSelected(TabButton button)
    {
        SelectedTab = button;
        ResetTabs();
        button.Background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < ObjectsTpSwap.Count; i++)
        {
            if (i == index)
            {
                ObjectsTpSwap[i].SetActive(true);
            }
            else
            {
                ObjectsTpSwap[i].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (SelectedTab != null && SelectedTab == button) { continue; }
                button.Background.sprite = tabIdle;
        }
    }

}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons; //Header buttons    
    public List<GameObject> ObjectsToSwap; //Body contents
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public TabButton SelectedTab;

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
    public void OnTabSelected(TabButton button) // display button's content
    {
        SelectedTab = button;
        ResetTabs();
        button.Background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < ObjectsToSwap.Count; i++)
        {
            if (i == index)
            {
                ObjectsToSwap[i].SetActive(true);
                
            }
            else
                ObjectsToSwap[i].SetActive(false);            
        }

        DOTween.Sequence()
                .Append(SelectedTab.transform.DOScale(1.1f, 0.5f).SetLoops(2, LoopType.Yoyo)
                .SetEase(Ease.Linear));
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

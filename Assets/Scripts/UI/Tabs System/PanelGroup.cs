using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelGroup : MonoBehaviour
{
    public GameObject[] Panels;
    public TabGroup TabGroup;
    public int PanelIndex;


    private void Start()
    {
        
    }


    private void Awake()
    {ShowCurrentPanel();}

    private void ShowCurrentPanel()
    {
        for (int i = 0; i < Panels.Length; i++)
        {
            if (i == PanelIndex)            
                Panels[i].gameObject.SetActive(true);            
            else            
                Panels[i].gameObject.SetActive(false);            
        }    
    }

    //public void SetPageIndex(int index)
    //{
    //    PanelIndex = index;
    //    ShowCurrentPanel();
    //}

}

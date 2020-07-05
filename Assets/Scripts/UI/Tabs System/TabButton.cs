﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour , IPointerEnterHandler,IPointerClickHandler,IPointerExitHandler
{
    public TabGroup TabGroup;
    public Image Background;

    private void Start()
    {
        Background = GetComponent<Image>();
        TabGroup.Subscribe(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {TabGroup.OnTabSelected(this);}

    public void OnPointerEnter(PointerEventData eventData)
    {TabGroup.OnTabEnter(this);}

    public void OnPointerExit(PointerEventData eventData)
    {TabGroup.OnTabExit(this);}
    
}

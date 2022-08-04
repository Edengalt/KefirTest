using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    public Button learn;
    public Button forget;
    public GameObject hiderLearn;
    public GameObject hiderForget;
    
    private Image hider;
   
    private bool disableble = true;
    private bool disableOnExit = false;

    private void Awake()
    {
        hider = GetComponent<Image>();
    }

    public void Init(bool canBeLearned, bool learned)
    {
        if (canBeLearned)
        {
            hiderLearn.SetActive(false);
            learn.interactable = true;
        }

        if (learned)
        {
            hiderForget.SetActive(false);
            forget.interactable = true;
        }
        hider.color = Color.white;
    }
    
    public void Disable(bool ignoreRule = false)
    {
        if(disableble || ignoreRule)
        {
            hiderLearn.SetActive(true);
            hiderForget.SetActive(true);
            hider.color = Color.clear;
            learn.interactable = false;
            forget.interactable = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        disableble = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        disableble = true;

        if (disableOnExit)
        {
            Disable(true);
            disableOnExit = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        disableOnExit = true;
    }
}

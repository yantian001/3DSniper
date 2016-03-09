﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonClick : MonoBehaviour
{

    public Events EventId;

    public AudioClip clickClip;

    Button btn;

    public void OnEnable()
    {
        btn = GetComponent<Button>();
        if(btn)
        {
            btn.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        LeanTween.dispatchEvent((int)EventId);
        if(clickClip)
        {
            LeanAudio.play(clickClip);
        }
        Debug.Log("button Clicked");
    }

    public void OnDisable()
    {
        if(btn)
        {
            btn.onClick.RemoveListener(OnButtonClick);
        }
    }
}

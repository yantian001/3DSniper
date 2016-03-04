﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPSSniperScreen : MonoBehaviour
{

    private GunHanddle gunHandler;

    public GameObject InScreen;
    public Slider ScreenSlider;

    float currentDelta = 0;

    // Use this for initialization
    void Start()
    {
        //gunHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<GunHanddle>();
        gunHandler = FindObjectOfType ( typeof(GunHanddle) ) as GunHanddle;
        if (ScreenSlider != null)
        {
            ScreenSlider.maxValue = gunHandler.CurrentGun.ZoomFOVLists.Length;
           // ScreenSlider.onValueChanged.AddListener(SliderDelta);
        }
    }

    public void OnEnable()
    {
        
    }

   public void SliderDelta(float delta)
    {
        int plus = 0;
        plus = delta > currentDelta ? 1 : -1;
        currentDelta = delta;
        gunHandler.CurrentGun.ZoomDelta(plus);
    }

    public void OnDisable()
    {
        ScreenSlider.onValueChanged.RemoveListener(SliderDelta);
    }



    // Update is called once per frame
    void Update()
    {
        if (gunHandler == null)
            return;
        if (gunHandler.CurrentGun.Zooming)
        {
            InScreen.SetActive(true);
            ScreenSlider.gameObject.SetActive(true);
            //ScreenSlider.value = 0;
            //currentDelta = 0;
        }
        else
        {
            InScreen.SetActive(false);
            ScreenSlider.gameObject.SetActive(false);

            currentDelta = 0;

        }
    }
}

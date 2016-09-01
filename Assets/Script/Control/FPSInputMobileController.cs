﻿using UnityEngine;
using System.Collections;
using CnControls;
public class FPSInputMobileController : MonoBehaviour
{

    private GunHanddle gunHanddle;
    private FPSController FPSmotor;

    public string aimHorizontal = "AimHorizontal";
    public string aimVertical = "AimVertical";

    public string moveHorizontal = "Horizontal";
    public string moveVertical = "Vertical";

    public string aimButtom = "Aim";
    public string fireButtom = "Fire1";
    public string switchButton = "Switch";
    public float touchSensMult = 0.05f;

    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void Awake()
    {
        FPSmotor = GetComponent<FPSController>();
        gunHanddle = GetComponent<GunHanddle>();
    }


    // Update is called once per frame
    void Update()
    {

        Vector2 aimDir = new Vector2(CnInputManager.GetAxis(aimHorizontal), CnInputManager.GetAxis(aimVertical)) * touchSensMult;
        FPSmotor.Aim(aimDir);
        ////MouseLock.MouseLocked = false;

        Vector3 moveDir = new Vector3(CnInputManager.GetAxis(moveHorizontal), 0, CnInputManager.GetAxis(moveVertical));
        FPSmotor.Move(moveDir);

        if (CnInputManager.GetButtonDown(aimButtom))
        {
            gunHanddle.Zoom();
        }

        if (CnInputManager.GetButtonDown(fireButtom))
        {
            gunHanddle.Shoot();
        }

        //if (CnInputManager.GetButtonDown(switchButton))
        //{
        //    gunHanddle.SwitchGun();
        //}
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gunHanddle.SwitchGun();
        }
    }
}

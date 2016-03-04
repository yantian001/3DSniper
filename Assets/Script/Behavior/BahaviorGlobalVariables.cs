﻿using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;

public class BahaviorGlobalVariables : MonoBehaviour {

    public float crouchTimeMax = 8f;

    public float oneShootTime = 1.6f;

    public float attackRate = 50f;
	// Use this for initialization
	void Start () {
        GlobalVariables.Instance.SetVariableValue("PlayerFired", false);

        float seed = 1f;
        if(GameValue.level < 4)
        {
            seed = .6f;
        }
        else if(GameValue.level < 11 && GameValue.level > 3)
        {
            seed = .7f;
        }
        else if (GameValue.level < 21 && GameValue.level > 10)
        {
            seed = .8f;
        }
        else if (GameValue.level < 31 && GameValue.level > 20)
        {
            seed = 1f;
        }
        else if (GameValue.level < 41 && GameValue.level > 30)
        {
            seed = 1.4f;
        }

        GlobalVariables.Instance.SetVariableValue("CounchTime", crouchTimeMax - 0.06f*GameValue.level);
        GlobalVariables.Instance.SetVariableValue("EnemyThinkTime", (oneShootTime - 0.01f * (float)GameValue.level) * (2f - seed));
        GlobalVariables.Instance.SetVariableValue("AttackRate", attackRate + GameValue.level * seed);

    }



}

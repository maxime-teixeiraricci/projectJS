﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Near Target")]
public class DecisionNearTarget : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return NearTarget(controler);
    }

    private bool NearTarget(FSMControler controler)
    {
        if (!controler.target) return false;
        else
        {
            Debug.Log(controler.agent.remainingDistance);
            return (controler.agent.remainingDistance <= controler.citizen.citizenSetting.distanceNearTarget && !controler.agent.pathPending);
        }
    }
}

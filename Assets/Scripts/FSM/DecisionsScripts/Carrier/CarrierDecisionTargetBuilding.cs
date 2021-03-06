﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Target Building")]
public class CarrierDecisionTargetBuilding : FSMDecision
{

    public override bool Decide(FSMControler controler)
    {
        return HaveTarget(controler);
    }

    public bool HaveTarget(FSMControler controler)
    {
        if (!controler.finalTarget) return false;
        return (controler.finalTarget.gameObject.GetComponent<Building>());
    }
}

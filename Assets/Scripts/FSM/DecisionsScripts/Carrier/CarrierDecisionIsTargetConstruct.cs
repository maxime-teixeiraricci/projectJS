using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Is Target Construct")]
public class CarrierDecisionIsTargetConstruct : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return IsTargetConstruct(controler);
    }

    private bool IsTargetConstruct(FSMControler controler)
    {
        if (!controler.finalTarget) return false;
        if (controler.finalTarget.GetComponent<Building>().isConstruct || (controler.finalTarget.GetComponent<Building>().enoughConstructToBuild && controler.finalTarget.GetComponent<Building>().enoughToolsToBuild))
        {
            controler.finalTarget = null;
            controler.manualTarget = null;
            return true;
        }

        return false;
        
    }
}

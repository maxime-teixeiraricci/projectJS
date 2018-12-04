using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Near Final Target")]
public class CarrierDecisionNearFinalTarget : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return NearFinalTarget(controler);
    }

    private bool NearFinalTarget(FSMControler controler)
    {
        if (!controler.finalTarget) return false;
        else
        {
            return (controler.agent.remainingDistance <= controler.citizen.citizenSetting.distanceNearTarget && !controler.agent.pathPending);
        }
    }
}

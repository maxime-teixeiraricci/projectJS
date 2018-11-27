using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Recolter/Near Target")]
public class RecolterDecisionNearTarget : FSMDecision
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
            return (controler.agent.remainingDistance <= controler.citizen.citizenSetting.distanceNearTarget && !controler.agent.pathPending);
        }
    }
}

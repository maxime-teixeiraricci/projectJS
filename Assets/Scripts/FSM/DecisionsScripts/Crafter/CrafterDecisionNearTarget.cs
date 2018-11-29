using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Recolter/Near Target")]
public class CrafterDecisionNearTarget : FSMDecision
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
            bool distance = controler.agent.remainingDistance <= controler.citizen.citizenSetting.distanceNearTarget && !controler.agent.pathPending;
            if (distance)
            {
                controler.citizen.GetComponent<MeshRenderer>().enabled = false;
            }
            return (distance);
        }
    }
}

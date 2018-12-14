using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Priority Target")]
public class CarrierDecisionPriorityTarget : FSMDecision
{

    public override bool Decide(FSMControler controler)
    {
        return PriorityTarget(controler);
    }

    public bool PriorityTarget(FSMControler controler)
    {
        if ((controler.manualTarget != null) && controler.finalTarget != controler.manualTarget)
        {
            controler.finalTarget = controler.manualTarget;
            return true;
        }

        else
        {
            return false;
        }
    }
}

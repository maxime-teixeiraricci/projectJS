using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Builder/Priority Target")]
public class BuilderDecisionPriorityTarget : FSMDecision
{

    public override bool Decide(FSMControler controler)
    {
        return PriorityTarget(controler);
    }

    public bool PriorityTarget(FSMControler controler)
    {
        if ((controler.manualTarget != null) && controler.target != controler.manualTarget)
        {
            controler.target = controler.manualTarget;
            return true;
        }

        else
        {
            return false;
        }
    }
}

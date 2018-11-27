using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Recolter/Target Destroy")]
public class RecolterDecisionTargetDestroy : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return controler.target == null;
    }
}

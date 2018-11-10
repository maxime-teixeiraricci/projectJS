using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Target Destroy")]
public class DecisionTargetDestroy : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return controler.target == null;
    }
}

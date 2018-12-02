using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Crafter/Target Built")]
public class CrafterDecisionTargetBuilt : FSMDecision
{

    public override bool Decide(FSMControler controler)
    {
        return TargetBuilt(controler);
    }

    public bool TargetBuilt(FSMControler controler)
    {
        if (!controler.target) return false;
        return (controler.target.GetComponent<Building>().isConstruct);
    }
}

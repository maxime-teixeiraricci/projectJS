using System.Collections;
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
        if (!controler.target) return false;
        return (controler.target.gameObject.tag == "Building");
    }
}

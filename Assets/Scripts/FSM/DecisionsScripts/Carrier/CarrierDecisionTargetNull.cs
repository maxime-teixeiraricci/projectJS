using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Target Null")]
public class CarrierDecisionTargetNull : FSMDecision
{

    public override bool Decide(FSMControler controler)
    {
        return HaveTarget(controler);
    }

    public bool HaveTarget(FSMControler controler)
    {
        return (controler.target == null);
    }
}

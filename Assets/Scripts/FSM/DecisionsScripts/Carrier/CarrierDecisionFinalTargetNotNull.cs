using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Final Target Not Null")]
public class CarrierDecisionFinalTargetNotNull : FSMDecision
{

    public override bool Decide(FSMControler controler)
    {
        return HaveFinalTarget(controler);
    }

    public bool HaveFinalTarget(FSMControler controler)
    {
        return (controler.finalTarget != null);
    }
}

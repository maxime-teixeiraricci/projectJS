using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Resources Not Available")]
public class CarrierDecisionResourcesNotAvailable : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return ResourcesNotAvailable(controler);
    }

    private bool ResourcesNotAvailable(FSMControler controler)
    {
        // TODO
        return true;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Resources Available")]
public class CarrierDecisionResourcesAvailable : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return ResourcesAvailable(controler);
    }

    private bool ResourcesAvailable(FSMControler controler)
    {
        // TODO
        return true;
    }
}

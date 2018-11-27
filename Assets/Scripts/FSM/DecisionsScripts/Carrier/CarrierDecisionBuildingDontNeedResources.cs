using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Building Dont Need Resources")]
public class CarrierDecisionBuildingDontNeedResources : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return BuildingDontNeedResources(controler);
    }

    private bool BuildingDontNeedResources(FSMControler controler)
    {
        // TODO
        return true;
    }
}

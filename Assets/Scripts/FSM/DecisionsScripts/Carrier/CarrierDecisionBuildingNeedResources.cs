using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Building Need Resources")]
public class CarrierDecisionBuildingNeedResources : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return BuildingNeedResources(controler);
    }

    private bool BuildingNeedResources(FSMControler controler)
    {
        // TODO
        return true;
    }
}

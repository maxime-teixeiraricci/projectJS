using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Building Dont Need Resources")]
public class CarrierDecisionBuildingDontNeedResources : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        bool res = BuildingDontNeedResources(controler);
        if (res)
        {
            controler.target = null;
            controler.finalTarget = null;
        }
        return res;
    }

    private bool BuildingDontNeedResources(FSMControler controler)
    {
        Building building = controler.finalTarget.GetComponent<Building>();
        return building.needRessources == false && building.needTools == false;
    }
}

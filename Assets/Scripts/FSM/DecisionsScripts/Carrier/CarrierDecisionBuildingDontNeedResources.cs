using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Building Dont Need Resources")]
public class CarrierDecisionBuildingDontNeedResources : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        bool res = BuildingNeedResources(controler);
        if (res)
        {
            controler.target = null;
            controler.finalTarget = null;
        }
        return res;
    }

    private bool BuildingNeedResources(FSMControler controler)
    {
        Building building = controler.target.GetComponent<Building>();
        return building.needRessource == false;
    }
}

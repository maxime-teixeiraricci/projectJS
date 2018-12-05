using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Still resource to transport")]
public class CarrierDecisionBuildingNeedResources : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return BuildingNeedResources(controler);
    }

    private bool BuildingNeedResources(FSMControler controler)
    {
        Building building = controler.finalTarget.GetComponent<Building>();
        return building.needRessource == true;
    }
}

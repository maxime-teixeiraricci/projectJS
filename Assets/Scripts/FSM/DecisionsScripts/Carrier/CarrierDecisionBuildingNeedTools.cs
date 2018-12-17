using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Building need tools")]
public class CarrierDecisionBuildingNeedTools : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return BuildingNeedTools(controler);
    }

    private bool BuildingNeedTools(FSMControler controler)
    {
        Building building = controler.finalTarget.GetComponent<Building>();
        return building.needTools;
    }
}
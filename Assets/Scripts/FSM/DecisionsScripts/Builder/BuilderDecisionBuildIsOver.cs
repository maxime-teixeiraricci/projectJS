using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Builder/Build Is Over")]
public class BuilderDecisionBuildIsOver : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return BuildIsOver(controler);
    }

    private bool BuildIsOver(FSMControler controler)
    {
        if (!controler.target) return false;
        Building building =  controler.target.GetComponent<Building>();
        if (!building) return false;
        if (building.isConstruct) controler.target = null;
        return building.isConstruct;
    }
}

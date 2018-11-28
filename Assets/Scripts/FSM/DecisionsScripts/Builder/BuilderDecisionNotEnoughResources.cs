using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Builder/Not Enough Resources")]
public class BuilderDecisionNotEnoughResources : FSMDecision
{

    public override bool Decide(FSMControler controler)
    {
        return HaveNotEnoughResources(controler);
    }

    public bool HaveNotEnoughResources(FSMControler controler)
    {
        if (!controler.target) return false;
        Building building = controler.target.gameObject.GetComponent<Building>();
        if (!building) return false;
        return !building.enoughtCostructToBuild;
    }
}
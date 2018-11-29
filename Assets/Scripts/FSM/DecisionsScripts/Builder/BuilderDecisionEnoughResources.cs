using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Builder/Enough Resources")]
public class BuilderDecisionEnoughResources : FSMDecision
{

    public override bool Decide(FSMControler controler)
    {
        return HaveEnoughResources(controler);
    }

    public bool HaveEnoughResources(FSMControler controler)
    {
        if (!controler.target) return false;
        Building building = controler.target.gameObject.GetComponent<Building>();
        if (!building) return false;
        return building.enoughConstructToBuild;
    }
}

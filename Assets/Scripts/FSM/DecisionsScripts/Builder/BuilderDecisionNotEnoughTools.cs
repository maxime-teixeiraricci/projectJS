using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Builder/Not Enough Tools")]
public class BuilderDecisionNotEnoughTools : FSMDecision
{

    public override bool Decide(FSMControler controler)
    {
        return HaveNotEnoughTools(controler);
    }

    public bool HaveNotEnoughTools(FSMControler controler)
    {
        if (!controler.target) return false;
        Building building = controler.target.gameObject.GetComponent<Building>();
        if (!building) return false;
        return !building.enoughToolsToBuild;
    }
}
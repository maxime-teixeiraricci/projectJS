using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Decisions/Builder/Enough Tools")]
public class BuilderDecisionEnoughTools : FSMDecision
{

    public override bool Decide(FSMControler controler)
    {
        return HaveEnoughTools(controler);
    }

    public bool HaveEnoughTools(FSMControler controler)
    {
        if (!controler.target) return false;
        Building building = controler.target.gameObject.GetComponent<Building>();
        if (!building) return false;
        return building.enoughToolsToBuild;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Crafter/Not Enough Resources")]
public class CrafterDecisionNotEnoughResources : FSMDecision
{

    public override bool Decide(FSMControler controler)
    {
        return !HaveEnoughResources(controler);
    }

    public bool HaveEnoughResources(FSMControler controler)
    {
        if (!controler.target) return false;
        Camp building = controler.target.gameObject.GetComponent<Camp>();
        if (!building) return false;
        return building.enoughResourcesToCraft;
    }
}
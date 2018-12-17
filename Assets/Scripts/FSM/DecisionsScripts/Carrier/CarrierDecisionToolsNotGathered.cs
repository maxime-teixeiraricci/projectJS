using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Tools Not Gathered")]
public class CarrierDecisionToolsNotGathered : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return ToolsNotGathered(controler);
    }

    private bool ToolsNotGathered(FSMControler controler)
    {
        Building target = controler.target.GetComponent<Building>();
        Citizen citizen = controler.GetComponent<Citizen>();
        foreach (Tool t in citizen.toolsToTransport.getToolsNeededTransport())
        {
            //s'il en reste renvoie true
            if (t.number < t.nbToTransport && target.needTools) return true;
        }
        return false;
    }
}

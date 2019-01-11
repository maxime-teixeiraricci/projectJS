using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Tools Gathered")]
public class CarrierDecisionToolsGathered : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return ToolsGathered(controler);
    }

    private bool ToolsGathered(FSMControler controler)
    {
        Building target = controler.target.GetComponent<Building>();
        Citizen citizen = controler.GetComponent<Citizen>();
        foreach (Tool t in citizen.toolsToTransport.getToolsNeededTransport())
        {
            //s'il en reste renvoie true
            if (t.number < 1) return false;
        }
        //controler.target = controler.finalTarget;
        return true;
    }
}
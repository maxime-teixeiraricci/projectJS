using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Resources Not Gathered")]
public class CarrierDecisionResourcesNotGathered : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return ResourcesNotGathered(controler);
    }

    private bool ResourcesNotGathered(FSMControler controler)
    {
        Building target = controler.finalTarget.GetComponent<Building>();
        Citizen citizen = controler.GetComponent<Citizen>();
        foreach (RessourceTank rT in citizen.ressourcesToTransport.getRessourcesNeededTransport())
        {
            //s'il en reste renvoie true
            if (rT.number<rT.numberToTransport && target.needRessources) return true;
        }

        foreach (Tool tool in citizen.toolsToTransport.getToolsNeededTransport())
        {
            //s'il en reste renvoie true
            if (tool.number < 1 && target.needTools) return true;
        }

        return false;
    }
}

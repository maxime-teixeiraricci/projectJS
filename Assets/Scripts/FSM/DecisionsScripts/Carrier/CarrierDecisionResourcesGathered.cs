using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Resources Gathered")]
public class CarrierDecisionResourcesGathered : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return ResourcesGathered(controler);
    }

    private bool ResourcesGathered(FSMControler controler)
    {
        Building target = controler.target.GetComponent<Building>();
        Citizen citizen = controler.GetComponent<Citizen>();
        foreach (RessourceTank rT in citizen.ressourcesToTransport.getRessourcesNeededTransport())
        {
            //s'il en reste renvoie true
            if (rT.number < rT.numberToTransport) return false;
        }
        //controler.target = controler.finalTarget;
        return true;
    }
}

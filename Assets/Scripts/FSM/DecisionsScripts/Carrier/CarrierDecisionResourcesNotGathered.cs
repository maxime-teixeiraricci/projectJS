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
        Building target = controler.target.GetComponent<Building>();
        Citizen citizen = controler.GetComponent<Citizen>();
        foreach (RessourceTank rT in citizen.ressourcesToTransport.getRessourcesNeededTransport())
        {
            //s'il en reste renvoie true
            if (rT.number<rT.numberToTransport) return true;
        }
        return false;
    }
}

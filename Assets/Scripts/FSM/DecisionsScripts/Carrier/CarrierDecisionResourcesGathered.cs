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
        Dictionary<Ressource, int> inv = controler.citizen.inventaire;
        Dictionary<Ressource, int> invBuilding = controler.target.GetComponent<Building>().ressourcesNeeded;
        return true;
        // TODO
        // Comparer les deux dicos entre eux
    }
}

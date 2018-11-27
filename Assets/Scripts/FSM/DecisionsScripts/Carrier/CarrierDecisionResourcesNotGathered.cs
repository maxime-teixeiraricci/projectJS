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
        Dictionary<Ressource, int> inv = controler.citizen.inventaire;
        Dictionary<Ressource, int> invBuilding = controler.target.GetComponent<Building>().ressourcesNeeded;
        return true;
        // TODO
        // Comparer les deux dicos entre eux
    }
}

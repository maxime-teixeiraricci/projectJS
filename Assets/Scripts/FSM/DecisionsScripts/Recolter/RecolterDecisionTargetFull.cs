using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Recolter/Target Full")]
public class RecolterDecisionTargetFull : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return targetFull(controler);
    }

    public bool targetFull(FSMControler controler)
    {
        int nbTotal = 0;
        int nbTotalPossible = 0;
        Citizen citizen = controler.GetComponent<Citizen>();
        if (!controler.target) return false;
        Building building = controler.target.GetComponent<Building>();
        if (!building) return false;
        if (building.inventory.ressourcesList.Count == 0) return false;
        foreach (RessourceTank rT in building.inventory.ressourcesList)
        {
            nbTotal += rT.number;
            nbTotalPossible += rT.numberLimit;
        }

        //if(nbTotal >= citizen.citizenSetting.inventorySize)
        if (nbTotal >= nbTotalPossible)
        {
            //controler.target = controler.finalTarget;
            citizen.workPlace = null;
            return true;
        }
        else
        {
            return false;
        }
    }

}

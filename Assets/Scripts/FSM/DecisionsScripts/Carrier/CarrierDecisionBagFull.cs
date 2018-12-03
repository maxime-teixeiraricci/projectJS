using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Bag Full")]
public class CarrierDecisionBagFull : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        int nbTotal = 0;
        int nbTotalPossible = 0;
        Citizen citizen = controler.GetComponent<Citizen>();
        foreach (RessourceTank rT in citizen.ressourcesToTransport.ressourcesList)
        {
            nbTotal += rT.number;
            nbTotalPossible += rT.numberLimit;
        }

        //if(nbTotal >= citizen.citizenSetting.inventorySize)
        if (nbTotal >= nbTotalPossible)
        {
            controler.target = controler.finalTarget;
            return true;
        }
        else
        {
            return false;
        }
    }

}
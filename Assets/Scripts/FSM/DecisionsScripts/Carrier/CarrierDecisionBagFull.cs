using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Bag Full")]
public class CarrierDecisionBagFull : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        int nbTotal = 0;
        Citizen citizen = controler.GetComponent<Citizen>();
        foreach (RessourceTank rT in citizen.ressourcesToTransport.ressourcesList)
        {
            nbTotal += rT.number;
        }

        if(nbTotal >= citizen.citizenSetting.inventorySize)
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Recolter/Bag Full")]
public class RecolterDecisionBagFull : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        bool boolBag = bagFull(controler);
        if (boolBag)
        {
            setTargetToCamp(controler);
        }

        return boolBag;
    }

    public bool bagFull(FSMControler controler)
    {
        int nbTotal = 0;
        int nbTotalPossible = 0;
        Citizen citizen = controler.GetComponent<Citizen>();
        if (citizen.ressourcesToTransport.ressourcesList.Count == 0) return false;
        foreach (RessourceTank rT in citizen.ressourcesToTransport.ressourcesList)
        {
            nbTotal += rT.number;
            nbTotalPossible += rT.numberLimit;
        }

        //if(nbTotal >= citizen.citizenSetting.inventorySize)
        if (nbTotal >= nbTotalPossible)
        {
            //controler.target = controler.finalTarget;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void setTargetToCamp(FSMControler controler)
    {
        //GameObject camp = GameObject.FindGameObjectWithTag("Camp");
        controler.target = controler.citizen.workPlace.gameObject;
    }
}
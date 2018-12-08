using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Recolter/Bag Empty")]
public class RecolterDecisionBagEmpty : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return bagEmpty(controler);
    }

    public bool bagEmpty(FSMControler controler)
    {
        int nbTotal = 0;
        Citizen citizen = controler.GetComponent<Citizen>();
        foreach (RessourceTank rT in citizen.ressourcesToTransport.ressourcesList)
        {
            nbTotal += rT.number;
        }

        if (nbTotal == 0)
        {
            //controler.target = controler.finalTarget;
            return true;
        }
        else
        {
            return false;
        }
    }

}
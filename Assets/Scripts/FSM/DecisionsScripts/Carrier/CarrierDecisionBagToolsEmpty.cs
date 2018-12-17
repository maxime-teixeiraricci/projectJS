using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Bag tools Empty")]
public class CarrierDecisionBagToolsEmpty : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return bagToolsEmpty(controler);
    }

    public bool bagToolsEmpty(FSMControler controler)
    {
        int nbTotal = 0;
        Citizen citizen = controler.GetComponent<Citizen>();
        foreach (Tool t in citizen.toolsToTransport.toolInventory)
        {
            nbTotal += t.number;
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
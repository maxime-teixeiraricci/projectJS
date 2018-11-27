using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Bag Empty")]
public class CarrierDecisionBagEmpty : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return controler.citizen.ressources.Count == 0;
    }

}
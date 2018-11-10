using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Bag Empty")]
public class DecisionBagEmpty : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return controler.citizen.ressources.Count == 0;
    }
    
}
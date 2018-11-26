using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableAI/Decisions/Recolter/Bag Not Full")]
public class RecolterDecisionBagNotEmpty : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return controler.citizen.ressources.Count != controler.citizen.citizenSetting.inventorySize;
    }

}

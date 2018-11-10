using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Bag Full")]
public class DecisionBagFull : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return controler.citizen.ressources.Count == controler.citizen.citizenSetting.inventorySize;
    }

}
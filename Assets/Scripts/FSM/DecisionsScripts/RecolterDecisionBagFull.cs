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
        return controler.citizen.ressources.Count == controler.citizen.citizenSetting.inventorySize;
    }

    public void setTargetToCamp(FSMControler controler)
    {
        GameObject camp = GameObject.FindGameObjectWithTag("Camp");
        controler.target = camp;
    }
}
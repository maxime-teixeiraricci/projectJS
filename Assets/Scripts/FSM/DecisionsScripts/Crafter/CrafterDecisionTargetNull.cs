﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Crafter/Target Null")]
public class CrafterDecisionTargetNull : FSMDecision
{

    public override bool Decide(FSMControler controler)
    {
        return HaveTarget(controler);
    }

    public bool HaveTarget(FSMControler controler)
    {
        if(controler.target == null)
        {
            controler.citizen.GetComponent<MeshRenderer>().enabled = true;
        }
        return (controler.target == null);
    }
}

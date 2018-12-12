﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Carrier/Go To Final Target")]
public class CarrierActionGoToFinalTarget : FSMAction
{

    public override void Act(FSMControler controler)
    {
        WalkTowardsFinalTarget(controler);
    }

    private void WalkTowardsFinalTarget(FSMControler controler)
    {
        if (controler.finalTarget)
        {
            controler.agent.SetDestination(controler.finalTarget.transform.position);
        }
    }

}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Builder/Go To Target")]
public class BuilderActionGoToTarget : FSMAction
{

    public override void Act(FSMControler controler)
    {
        WalkTowardsTarget(controler);
    }

    private void WalkTowardsTarget(FSMControler controler)
    {
        if (controler.target)
        {
            Citizen citizen = controler.GetComponent<Citizen>();
            citizen.refreshSoundBools();
            citizen.isWalking = true;
            controler.agent.SetDestination(controler.target.transform.position);
        }
    }

}

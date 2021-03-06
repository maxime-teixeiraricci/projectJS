﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Target Camp")]
public class CarrierDecisionTargetCamp : FSMDecision
{

    public override bool Decide(FSMControler controler)
    {
        return HaveTarget(controler);
    }

    public bool HaveTarget(FSMControler controler)
    {
        if (!controler.finalTarget) return false;
        bool verify = (controler.finalTarget.gameObject.tag == "Camp");
        if (verify) controler.target = controler.finalTarget;
        return verify;
    }
}

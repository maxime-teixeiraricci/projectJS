using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Shelter Space Available")]
public class CarrierDecisionShelterSpaceAvailable : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return ShelterSpaceAvailable(controler);
    }

    private bool ShelterSpaceAvailable(FSMControler controler)
    {
        // TODO
        return true;
    }
}

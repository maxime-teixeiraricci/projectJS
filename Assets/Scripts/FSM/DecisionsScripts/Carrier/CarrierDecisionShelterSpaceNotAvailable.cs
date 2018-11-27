using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Carrier/Shelter Space Not Available")]
public class CarrierDecisionShelterSpaceNotAvailable : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return ShelterSpaceNotAvailable(controler);
    }

    private bool ShelterSpaceNotAvailable(FSMControler controler)
    {
        // TODO
        return true;
    }
}

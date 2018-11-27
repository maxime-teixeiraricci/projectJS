using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Carrier/Go To Target")]
public class CarrierActionGoToTarget : FSMAction
{

    public override void Act(FSMControler controler)
    {
        WalkTowardsTarget(controler);
    }

    private void WalkTowardsTarget(FSMControler controler)
    {
        if (controler.target)
        {
            controler.agent.SetDestination(controler.target.transform.position);
        }
    }

}

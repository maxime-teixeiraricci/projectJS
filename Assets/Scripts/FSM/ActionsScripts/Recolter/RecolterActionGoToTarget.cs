using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Recolter/Go To Target")]
public class RecolterActionGoToTarget : FSMAction
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

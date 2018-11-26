using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Recolter/Go To Resources")]
public class RecolterActionGoToResources : FSMAction {

    public override void Act(FSMControler controler)
    {
        WalkTowardsRessource(controler);
    }

    private void WalkTowardsRessource(FSMControler controler)
    {
        if (controler.target)
        {
            controler.agent.SetDestination(controler.target.transform.position);
        }
    }

}

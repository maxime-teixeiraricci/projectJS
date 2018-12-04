using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Recolter/Null Stop")]
public class NullStop : FSMAction
{
    public override void Act(FSMControler controler)
    {
        Stop(controler);
    }

    private void Stop(FSMControler controler)
    {
        controler.agent.isStopped = true;
    }


}
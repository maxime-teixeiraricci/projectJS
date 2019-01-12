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
        Citizen citizen = controler.GetComponent<Citizen>();
        citizen.isWalking = false;
        citizen.GetComponent<FSMControler>().manualTarget = null;
        citizen.GetComponent<FSMControler>().finalTarget = null;
        controler.agent.isStopped = true;
    }


}